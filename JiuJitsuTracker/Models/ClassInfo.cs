using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JiuJitsuTracker.Models
{
    public class ClassInfo
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name (optional)")]
        public string Name { get; set; }
        [DisplayName("Belt Color")]
        public string BeltColor { get; set; }
        [DisplayName("Uniform (gi or no gi)")]
        public string ClassUniform { get; set; }
        [Required]
        [DisplayName("Class Focus")]
        public string ClassFocus { get; set; }
        [DisplayName("Mat Time")]
        [Range(0, 24, ErrorMessage ="There are 24 hours in a day")]
        public double MatTime { get; set; }
        public double TotalMatTime { get; set; }
        public DateTime ClassLogDateTime { get; set; } = DateTime.Now;
    }
}
