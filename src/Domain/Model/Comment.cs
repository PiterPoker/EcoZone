using System;

namespace Domain.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Body { get; set; }

        public Unit Unit { get; set; }
        public int UnitId { get; set; }
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
    }
}