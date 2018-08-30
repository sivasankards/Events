using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApi.Models
{
    public class NotificationModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}