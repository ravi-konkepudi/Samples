using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cricket.Models
{    

    [Table("Team")]
    public class Team
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public virtual int TournamentId { get; set; }
        [ForeignKey("TournamentId")]
        public Tournament Tournament { get; set; }
        public string TeamName { get; set; }
        public virtual ICollection<Schedule> HomeMatches { get; set; }
        public virtual ICollection<Schedule> AwayMatches { get; set; }
    }

    public class TeamsModel
    {
        [Required]
        [Display(Name = "TournamentId")]
        public int TournamentId { get; set; }
        
        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
    }
}