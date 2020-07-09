using System.ComponentModel.DataAnnotations;

namespace AXA.Exam.API.Classes {
    public class RegisterDal {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string PositionApplied { get; set; }
        [Required]
        public string Source { get; set; }
    }
}
