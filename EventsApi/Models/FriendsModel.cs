using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApi.Models
{
    public class FriendsModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public int FriendsId { get; set; }
        public string FriendsList { get; set; }
        public int EventId { get; set; }
    }
}