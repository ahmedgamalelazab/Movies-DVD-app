

using System.Collections.Generic;
using App.Models;

namespace App.ViewModel {

    public class SalatyProfileViewModel {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Salah> Salahs { get; set; }


    }





}