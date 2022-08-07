using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models {

    public class Salah : BaseEntity {

        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Name { get; set; }       
        public bool IsPrayed { get; set; }
        public Tasbeeh Tasbeeh { get; set; }        
        public User User { get; set; }

    }

}