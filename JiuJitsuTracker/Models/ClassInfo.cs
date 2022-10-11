namespace JiuJitsuTracker.Models
{
    public class ClassInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniformClassType { get; set; }
        public string BeltColor { get; set; }
        public string ClassFocus { get; set; }
        public DateTime ClassLogDateTime { get; set; } = DateTime.Now;
    }
}
