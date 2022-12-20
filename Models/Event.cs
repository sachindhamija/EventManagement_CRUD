using System;
using System.Collections.Generic;

namespace EventManagement_CRUD.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Organizer { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
