using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDrivingMVC.Models
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Resulte { get; set; }
        //public int? ActivityTypeId { get; set; }
        //[ForeignKey("ActivityTypeId")]
        //public virtual ActivityType ActivityType { get; set; }
        public int? BookingLogId { get; set; }
        [ForeignKey("BookingLogId")]
        public virtual BookingLog BookingLog { get; set; }
    }
}