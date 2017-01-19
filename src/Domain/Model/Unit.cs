using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string CoverType { get; set; }
        public long Views { get; set; } = 0;
        public bool IsApproved { get; set; } = false;

        public List<Comment> Comments { get; set; }
        public List<UnitTags> Tags { get; set; }
        public List<Like> Likes { get; set; }
        public List<Block> Blocks { get; set; }

        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
        public Unit PendingUnit { get; set; }
        public int? PendingUnitId { get; set; }

        public void SortBlocks()
        {
            Blocks.Sort((x, y) => x.Number.CompareTo(y.Number));
        }
    }
}