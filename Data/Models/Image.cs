using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Content { get; set; }
    }
}