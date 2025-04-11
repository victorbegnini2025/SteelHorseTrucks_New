using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelHorseTrucks.Models
{
    public class Trucks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Year of Manufacture")]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        [Required]
        [Display(Name = "Payload Capacity (ton)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PayloadCapacity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Warranty (year(s))")]
        public int Warranty { get; set; }
    }
}
