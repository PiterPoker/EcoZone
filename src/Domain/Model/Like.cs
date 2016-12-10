namespace Domain.Model
{
    public class Like
    {
        public int Id { get; set; }
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
    }
}