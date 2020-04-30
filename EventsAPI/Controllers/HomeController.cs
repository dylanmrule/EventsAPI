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

namespace EventsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Config _config;
        private readonly DiscoveryApi _discovery;
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
            var states = new States();
            return View(states);
        }
        public async Task<IActionResult> Events(string city, string stateCode)
        {
            var request = new SearchEventsRequest();
            request.AddQueryParameter(SearchEventsQueryParameters.city, city);
            request.AddQueryParameter(SearchEventsQueryParameters.stateCode, stateCode);
            var response = await _discovery.Events.SearchEventsAsync(request);
            EventsResponse result = new EventsResponse();
            result.Events = response._embedded.Events;
            return View(result);
        }
        public async Task<IActionResult> Venues(string statecode)
        {
            var request = new SearchVenuesRequest();
            request.AddQueryParameter(SearchVenuesQueryParameters.stateCode, statecode);
            var response = await _discovery.Venues.SearchVenuesAsync(request);
            VenuesResponse result = new VenuesResponse();
            result.Venues = response._embedded.Venues;
            return View(result);
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
