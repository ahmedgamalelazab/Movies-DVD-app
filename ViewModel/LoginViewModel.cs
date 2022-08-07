


using System.ComponentModel.DataAnnotations;

namespace App.ViewModel {


    public class LoginViewModel {

        [Required]
        [DataType(DataType.Text,ErrorMessage ="pleas enter your email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password,ErrorMessage ="Pleas enter your Password")]
        public string Password { get; set; }


    }



}