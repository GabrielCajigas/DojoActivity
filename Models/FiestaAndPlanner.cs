using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Belt.Models;

namespace Belt.Models
{

    public class FiestaAndPlanner

    {
        [Key]
        public int FiestaAndPlannerId { get; set; }


        public int UserId { get; set; }
        public int FiestaId { get; set; }

        public User Planner { get; set; }
        public TheFiesta Fiesta { get; set; }



    }


}