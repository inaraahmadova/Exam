using System.ComponentModel.DataAnnotations;

namespace Exam9.ViewModels
{
    public class LoginVM
    {
        [MaxLength(25), MinLength(3)]
        public string User { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
