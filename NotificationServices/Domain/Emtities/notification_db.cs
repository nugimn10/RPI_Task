using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace  RPI_Task.Domain.Entities
{
    public class NotificationTB
    {
        public int id { get; set; }    
        public string title { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
    
    public class Notification_logsTB
    {
        public int id { get; set; }
        public int notification_id { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public int target { get; set; }
        public string email_destination { get; set; }
        public DateTime read_at { get; set; }
        public DateTime create_at { get; set; } =DateTime.Now;
        public DateTime update_at { get; set; } =DateTime.Now;

        // public Users users {get; set;}
        [JsonIgnore]
        public NotificationTB notification {get; set;}
    }
    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
    }

    
}