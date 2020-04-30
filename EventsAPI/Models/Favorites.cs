using System;
using System.Collections.Generic;

namespace EventsAPI.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime? StartDate { get; set; }
        public string Venue { get; set; }
    }
}
