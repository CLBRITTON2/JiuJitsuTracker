using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JiuJitsuTracker.Models
{
    public class ClassInfo
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [DisplayName("Name (Optional)")]
        public string Name { get; set; }
        [DisplayName("Belt Color")]
        public string BeltColor { get; set; }
        [DisplayName("Uniform (Gi or No Gi)")]
        public string ClassUniform { get; set; }
        [Required]
        [DisplayName("Class Focus")]
        public string ClassFocus { get; set; }
        [DisplayName("Mat Time (Hours)")]
        [Range(0, 24, ErrorMessage ="There are 24 hours in a day")]
        public double MatTime { get; set; }
        public double TotalMatTime { get; set; }
        public DateTime ClassLogDateTime { get; set; } = DateTime.Now;
    }
}
