using System;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModel {


    public class RegisterUserViewModel {

        [Display(Name ="First Name")]
        [DataType(DataType.Text,ErrorMessage ="Pleas Enter your First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        [DataType(DataType.Text,ErrorMessage ="Pleas Enter your Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Pleas Enter your Email Address")]
        [Required]
        public string EmailAddress { get; set; }

        [Display(Name ="Password")]
        [DataType(DataType.Password,ErrorMessage ="Pleas Enter your Password")]
        [Required]
        public string Password { get; set; }
        
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password,ErrorMessage ="Pleas Confirm the Password")]
        [Required]
        public string ConfirmPassword { get; set; }

    }

}