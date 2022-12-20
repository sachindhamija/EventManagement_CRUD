namespace EventManagement_CRUD.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double Price { get; set; }
        public int EventId { get; set; }

        public Event Event { get; set; }

    }
}
