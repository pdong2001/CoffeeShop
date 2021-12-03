using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedTime { get; set; }

        public string Note { get; set; }

        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public ICollection<BillLine> BillLines { get; set; }
    }
}
