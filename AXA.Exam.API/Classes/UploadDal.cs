using System.ComponentModel.DataAnnotations;

namespace AXA.Exam.API.Classes {
    public class UploadDal {
        [Required]
        public UploadFile File { get; set; }
    }
}
