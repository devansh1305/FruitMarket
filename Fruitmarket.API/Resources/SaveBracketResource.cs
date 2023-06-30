using System.ComponentModel.DataAnnotations;

namespace FruitMarket.API.Resources
{
    public class SaveBracketResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}