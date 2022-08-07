using System;
using System.Collections.Generic;
using System.Collections;


namespace App.Models {


    public class User : BaseEntity {

        public User()
        {
            Salahs = new HashSet<Salah>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }       
        public ICollection<Salah> Salahs { get; set; }

    }


}







