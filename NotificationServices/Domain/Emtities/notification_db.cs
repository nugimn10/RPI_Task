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
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
    
    public class Notification_logsTB
    {
        public int id { get; set; }
        public int notification_id { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public List<Target> target { get; set; }
        public string email_destination { get; set; }
        public DateTime read_at { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }

        // public Users users {get; set;}
        [JsonIgnore]
        public NotificationTB notification {get; set;}
    }

    public class Target
    {
        public int id { get; set; }
        public string message { get; set; }
    }
    
}