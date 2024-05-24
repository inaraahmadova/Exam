using System.ComponentModel.DataAnnotations;

namespace Exam9.ViewModels
{
    public class RegisterVM
    {
        [MaxLength(25), MinLength(3)]
        public string Name { get; set; }
        [MaxLength(25), MinLength(3)]
        public string Surname { get; set; }
        [MaxLength(25), MinLength(3)]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password"),DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}
