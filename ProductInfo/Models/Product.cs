using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public string size { get; set; }
        [Required]
        public double price { get; set; }


    }
}
