using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApi.Models
{
    public class EventInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool IsPublic { get; set; }
        public int UserId { get; set; }
    }
}