using CoffeeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{
    public class WebInfo
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public int? ImageId { get; set; }
    }
}
