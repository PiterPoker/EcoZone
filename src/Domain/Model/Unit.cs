using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Unit
    {
        public Unit()
        {
            Views = 0;
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public byte[] Cover { get; set; }
        public string CoverType { get; set; }
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
        public long Views { get; set; }
        public List<Comment> Comments { get; set; }
        public List<UnitTags> Tags { get; set; }
        public List<Like> Likes { get; set; }

        public List<Block> Blocks { get; set; }

        public void SortBlocks()
        {
            Blocks.Sort((x, y) => x.Number.CompareTo(y.Number));
        }
    }
}