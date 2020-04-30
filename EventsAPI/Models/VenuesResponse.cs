using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketmaster.Core.V2.Models;

namespace EventsAPI.Models
{
    public class VenuesResponse
    {
        public List<Venue> Venues { get; set; }
    }
}
