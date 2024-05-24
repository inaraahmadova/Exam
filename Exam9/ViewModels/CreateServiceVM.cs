using System.ComponentModel.DataAnnotations;

namespace Exam9.ViewModels
{
    public class CreateServiceVM
    {
        [Required,MaxLength(25)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Subtitle { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}
