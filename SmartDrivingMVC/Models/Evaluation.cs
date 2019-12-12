using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDrivingMVC.Models
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Resulte { get; set; }
        public int ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
    }
}