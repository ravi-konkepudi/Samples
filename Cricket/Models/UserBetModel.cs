using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cricket.Models
{
    [Table("UserBet")]
    public class UserBet
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserBetId { get; set; }

        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public virtual Schedule Schedule { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }

        public int BetAmount { get; set; }
        public DateTime BetOnDate { get; set; }
    }

    public class UserBetModel
    {
        [Required]
        [Display(Name = "ScheduleId")]
        public int ScheduleId { get; set; }

        [Required]
        [Display(Name = "Bet Amount")]
        public int BetAmount { get; set; }

        [Required]
        [Display(Name = "Betting Date")]
        public DateTime BetOnDate { get; set; }
    }
}