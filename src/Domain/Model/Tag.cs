using System.Collections.Generic;

namespace Domain.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UnitTags> Units { get; set; }
    }
}