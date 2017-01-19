namespace Domain.Model
{
    public class Block
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public string ImageType { get; set; }

        public BlockType Type { get; set; }
        public int TypeId { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
    }
}