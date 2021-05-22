using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myPennyFarthing.Models
{
    [Table("Bike", Schema = "myPennyFarthing")]
    public class Bike
    {
        //   F I E L D S  &  P R O P E R T I E S

        public int Id { get; set; }

        [Required(ErrorMessage = "Year Is Required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Make Is Required")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model Is Required")]
        public string Model { get; set; }


        public string Color { get; set; }


        public IEnumerable<MX> MXs { get; set; }


        public IEnumerable<Ride> Rides { get; set; }


        public int UserId { get; set; }


        //   C O N T R O L L E R S



        //   M E T H O D S
    }
}
