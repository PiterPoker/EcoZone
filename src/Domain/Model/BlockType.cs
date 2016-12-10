using System.Collections.Generic;

namespace Domain.Model
{
    public class BlockType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Block> Blocks { get; set; }
    }
}