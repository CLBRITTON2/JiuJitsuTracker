using System.ComponentModel.DataAnnotations;

namespace JiuJitsuTracker.Models
{
    public class ClassInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BeltColor { get; set; }
        public string ClassUniformType { get; set; }
        public string ClassFocus { get; set; }
        public int MatTime { get; set; }
        public int TotalMatTime { get; set; }
        public DateTime ClassLogDateTime { get; set; } = DateTime.Now;
    }
}
