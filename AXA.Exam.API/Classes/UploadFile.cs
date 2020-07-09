using System.ComponentModel.DataAnnotations;

namespace AXA.Exam.API.Classes {
    public class UploadFile {
        [Required]
        public string Mime { get; set; }
        [Required]
        public string Data { get; set; }
    }
}
