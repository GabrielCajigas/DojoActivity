using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Belt.Models;

namespace Belt.Models
{
    public class TheFiesta
    {
        [Key]
        public int FiestaId { get; set; }

        public int PlannerId { get; set; }
        public string PlannerName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Tittle should be a minimum of 3 characters")]

        public string Tittle { get; set; }



        public TimeSpan Time { get; set; }
        public string Tiempo { get; set; }


        [Required]
        public DateTime Date { get; set; }


        public int Duration { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description should be a minimum of 10 characters")]

        public string Description { get; set; }



        public List<FiestaAndPlanner> JoinedUsers { get; set; }


    }


}