using System.ComponentModel.DataAnnotations;

namespace JiuJitsuTracker.Models
{
    public class ClassInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BeltColor { get; set; }
        public string ClassUniform { get; set; }
        [Required]
        public string ClassFocus { get; set; }
        public double MatTime { get; set; }
        public double TotalMatTime { get; set; }
        public DateTime ClassLogDateTime { get; set; } = DateTime.Now;
    }
}
