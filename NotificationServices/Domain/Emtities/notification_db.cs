using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
namespace  RPI_Task.Domain.Entities
{
    public class NotificationTB
    {
        public int id { get; set; }    
        public string title { get; set; }
        public string message { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
    
    public class Notification_logsTB
    {
        public int id { get; set; }
        public int notification_id { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public int target { get; set; }
        public string email_destination { get; set; }
        public long read_at { get; set; }
        public long create_at { get; set; }
        public long update_at { get; set; }

        // public Users users {get; set;}
        public NotificationTB notification {get; set;}
    }
    
}