using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cricket.Models
{    
    [Table("Tournament")]
    public class Tournament
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class TournamentModel
    {
        [Required]
        [Display(Name = "Tournament Name")]
        public string TournamentName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}