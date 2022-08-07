using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models {

    public class Tasbeeh : BaseEntity {
        
        [ForeignKey("Salah")]
        public int SalahId { get; set; }

        [Display(Name ="عدد التكبيرات")]
        public int TakpeerCount { get; set; } = 0;

        [Display(Name ="عدد ذكر حمد الله")]
        public int HamdCount { get; set; } = 0;

        [Display(Name ="عدد الإستغفارات")]
        public int AstghparCount { get; set; } = 0;
        public Salah Salah { get; set; }      

    }




}