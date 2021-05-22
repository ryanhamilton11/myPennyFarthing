using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myPennyFarthing.Models
{
    [Table("Ride", Schema = "myPennyFarthing")]
    public class Ride
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [UIHint("date")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [UIHint("time")]
        public DateTime Time { get; set; }

        [Column(TypeName = "float(5,2)")]
        [UIHint("number")]
        public float Distance { get; set; }

        [UIHint("number")]
        public float AvgCadence { get; set; }

        [UIHint("number")]
        public int AvgHR { get; set; }

        [Column(TypeName = "float(3,1)")]
        [UIHint("number")]
        public float AvgSpeed { get; set; }

        [UIHint("number")]
        public int Ascent { get; set; }

        [UIHint("number")]
        public int Descent { get; set; }

        [Column(TypeName = "float(3,1)")]
        [UIHint("number")]
        public float HighGrade { get; set; }

        [Column(TypeName = "float(3,1)")]
        [UIHint("number")]
        public float LowGrade { get; set; }


        public int BikeId { get; set; }


        public Bike Bike { get; set; }
    }
}
