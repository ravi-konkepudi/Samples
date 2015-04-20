using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cricket.Models
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }
        
        public  int TournamentId { get; set; }
        [ForeignKey("TournamentId")]
        public virtual Tournament Tournament { get; set; }
        
        public  int HomeTeamId { get; set; }
        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }
        
        public  int GuestTeamId { get; set; }
        [ForeignKey("GuestTeamId")]
        public virtual Team GuestTeam { get; set; }
        
        public DateTime MatchDate { get; set; }
        public DateTime MatchTime { get; set; }
        public float HomePoints { get; set; }
        public float GuestPoints { get; set; }
        public string Ground { get; set; }
        public string City { get; set; }
        public string Result { get; set; }
    }

    public class ScheduleModel
    {
        [Required]
        [Display(Name = "TournamentId")]
        public int TournamentId { get; set; }

        [Required]
        [Display(Name = "Match Date")]
        public DateTime MatchDate { get; set; }

        [Required]        
        [Display(Name = "Match Time (IST Hrs)")]
        public TimeSpan MatchTime { get; set; }

        [Required]
        [Display(Name = "Match Details")]
        public string MatchDetails { get; set; }

        [Required]
        [Display(Name = "Ground")]
        public string Ground { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Result")]
        public string Result { get; set; }
    }
}