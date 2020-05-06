using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketmaster.Core.V2.Models;

namespace EventsAPI.Models
{
    public class EventsResponse
    {
        public List<Event> Events { get; set; }
        public List<string> Favorites { get; set; }
        public string PageLink { get; set; }
        public int Page { get; set; }
    }
}
