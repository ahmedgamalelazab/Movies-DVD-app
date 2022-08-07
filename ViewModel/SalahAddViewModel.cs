



using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.ViewModel {


    public class SalahAddViewModel {

        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        public bool IsPrayed { get; set; } = false;
        
        public Tasbeeh Tasbeeh { get; set; }        


        // public int MyProperty { get; set; }


    }




}