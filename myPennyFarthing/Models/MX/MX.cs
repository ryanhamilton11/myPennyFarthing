using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myPennyFarthing.Models
{
    [Table("Maintenance", Schema = "myPennyFarthing")]
    public class MX
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [UIHint("date")]
        public DateTime Date { get; set; }

        public string Action { get; set; }

        [Column(TypeName = "float(7,2)")]
        [UIHint("number")]
        public float Mileage { get; set; }

        [Column(TypeName = "float(7,2)")]
        [UIHint("number")]
        public float Cost { get; set; }

        public int BikeId { get; set; }

        public Bike Bike { get; set; }

    }
}
