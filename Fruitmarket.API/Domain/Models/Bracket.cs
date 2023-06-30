using System.Collections.Generic;

namespace FruitMarket.API.Domain.Models
{
    public class Bracket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}