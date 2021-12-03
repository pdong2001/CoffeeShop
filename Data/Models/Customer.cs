using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string SurName { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        [MinLength(8)]
        public string UserName { get; set; }

        [ForeignKey("ImageId")]
        public Image Avatar { get; set;}

        public int? ImageId { get; set; }

        public ICollection<Bill> Bills { get; set; }
    }
}
