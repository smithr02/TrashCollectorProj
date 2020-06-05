using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class PickUp
    {
        [Key]

        public int Id { get; set; }




        [ForeignKey("Customer")] 

        public int CustomerId { get; set; }
        Customer Customer { get; set; }
    }
}
