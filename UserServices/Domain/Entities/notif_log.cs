using System;
using System.Collections.Generic;

namespace UserServices.Domain.Entities
{
    public class PostNotif
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public List<Target> Targets { get; set; }
    }

    public class Target
    {
        public int Id { get; set; }
        public string Email_destination { get; set; }
    }   
}