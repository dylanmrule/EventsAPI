using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        [Required]
        public string EventId { get; set; }
        public string EventName { get; set; }
        public DateTime? StartDate { get; set; }
        public string Venue { get; set; }
        public string VenueID { get; set; }
    }
}
