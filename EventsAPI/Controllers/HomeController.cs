using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EventsAPI.Models;
using System.Net.Http;
using Ticketmaster.Discovery.V2;
using Ticketmaster.Core;
using Ticketmaster.Discovery;
using Ticketmaster.Discovery.V2.Models;
using Ticketmaster.Core.V2.Models;
using RestSharp;
using Newtonsoft.Json;

namespace EventsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Config _config;
        private readonly DiscoveryApi _discovery;
        private readonly EventsAPIDBContext _context = new EventsAPIDBContext();
        //nuget package documentation for DiscoveryAPI https://github.com/SerhiiVoznyi/Ticketmaster-SDK/tree/master/src/Ticketmaster.Discovery

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _config = new Config("2kVlEu5eTcizQZ73bkzcleUGRaFcJhxp");
            var factory = new ClientFactory();
            _discovery = factory.Create<DiscoveryApi>(_config);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Events(string city, string stateCode)
        {
            EventsResponse events = new EventsResponse() { Events = new List<Event>(), 
                Favorites = new List<string>() };
            
            foreach (var favorite in _context.Favorites)
            {
                events.Favorites.Add(favorite.EventId);
            }

            events.PageLink = "events?apikey=2kVlEu5eTcizQZ73bkzcleUGRaFcJhxp"
                + "&locale=*&city=" + city + "&statecode=" + stateCode;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://app.ticketmaster.com/discovery/v2/");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            var response = await client.GetStringAsync(events.PageLink);
            var result = JsonConvert.DeserializeObject<SearchEventsResponse>(response);
            events.Events.AddRange(result._embedded.Events);
            events.Page = result.Page.Number;

            return View(events);

            /*Previous method below using ticketmaster library.
            
            var request = new SearchEventsRequest();
            EventsResponse result = new EventsResponse();
            List<Event> events = new List<Event>();
            request.AddQueryParameter(SearchEventsQueryParameters.city, city);
            request.AddQueryParameter(SearchEventsQueryParameters.stateCode, statecode);
            for (int i = 0; i < 3; i++)
            {
                request.AddQueryParameter(SearchEventsQueryParameters.page, i.ToString());
                var response = await _discovery.Events.SearchEventsAsync(request);
                events.AddRange(response._embedded.Events);
                
            }*/

        }
        //MVC did not play nicely with overloading
        [ActionName("Events2")]
        public async Task<IActionResult> Events(string link, int page)
        {
            EventsResponse events = new EventsResponse()
            {
                Events = new List<Event>(),
                Favorites = new List<string>()
            };

            foreach (var favorite in _context.Favorites)
            {
                events.Favorites.Add(favorite.EventId);
            }

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://app.ticketmaster.com/discovery/v2/");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");
            string newLink = string.Concat(link + "&page=" + page.ToString());
            var response = await client.GetStringAsync(newLink);
            var result = JsonConvert.DeserializeObject<SearchEventsResponse>(response);
            events.Events.AddRange(result._embedded.Events);
            events.Page = result.Page.Number;
            events.PageLink = link;

            return View("~/Views/Home/Events.cshtml", events);
        }
        public async Task<IActionResult> Venues(string statecode)
        {
            //VenuesResponse venues = new VenuesResponse()
            //{
            //    Venues = new List<Venue>(),
            //    Favorites = new List<string>()
            //};

            //foreach (var favorite in _context.Favorites)
            //{
            //    events.Favorites.Add(favorite.EventId);
            //}

            //events.PageLink = "events?apikey=2kVlEu5eTcizQZ73bkzcleUGRaFcJhxp"
            //    + "&locale=*&city=" + city + "&statecode=" + stateCode;
            //var client = new HttpClient();
            //client.BaseAddress = new Uri("https://app.ticketmaster.com/discovery/v2/");
            //client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            //var response = await client.GetStringAsync(events.PageLink);
            //var result = JsonConvert.DeserializeObject<SearchEventsResponse>(response);
            //events.Events.AddRange(result._embedded.Events);
            //events.Page = result.Page.Number;

            //return View(events);




            var request = new SearchVenuesRequest();
            request.AddQueryParameter(SearchVenuesQueryParameters.stateCode, statecode);
            var response = await _discovery.Venues.SearchVenuesAsync(request);
            VenuesResponse result = new VenuesResponse();

            //This will break if the API response is null.

            result.Venues = response._embedded.Venues;
            return View(result);
        }

        [ActionName("Venues2")]
        public async Task<IActionResult> Venues(string link, int page)
        {
            VenuesResponse venues = new VenuesResponse()
            {
                Venues = new List<Venue>(),
                Favorites = new List<string>()
            };

            foreach (var favorite in _context.Favorites)
            {
                venues.Favorites.Add(favorite.VenueID);
            }

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://app.ticketmaster.com/discovery/v2/");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");
            string newLink = string.Concat(link + "&page=" + page.ToString());
            var response = await client.GetStringAsync(newLink);
            var result = JsonConvert.DeserializeObject<SearchVenuesResponse>(response);
            venues.Venues.AddRange(result._embedded.Venues);
            venues.Page = result.Page.Number;
            venues.PageLink = link;

            return View("~/Views/Home/Venues.cshtml", venues);
        }
        public async Task<IActionResult> EventDetails(string id)
        {
            var request = await _discovery.Events.GetEventDetailsAsync(new GetRequest(id));
            return View(request);
        }
        public async Task<IActionResult> AddToFavorites(string id)
        {
            var request = await _discovery.Events.GetEventDetailsAsync(new GetRequest(id));
            Favorites newFavorite = new Favorites() { EventId = id, EventName = request.Name,
                StartDate = request.Dates.Start.DateTime, Venue = request._embedded.Venues[0].Name };
            _context.Favorites.Add(newFavorite);
            _context.SaveChanges();
            return View(request);
        }
        public IActionResult DeleteFromFavorites(string id)
        {
            Favorites selected = _context.Favorites.FirstOrDefault(e => e.EventId == id);
            _context.Favorites.Remove(selected);
            _context.SaveChanges();
            return View(selected);
        }
        public async Task<IActionResult> Favorites()
        {
            var model = _context.Favorites.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
