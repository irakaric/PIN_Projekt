using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PIN_Projekt.Models
{
    public class Predmeti
    {
        public int Id { get; set; }
        
        [DisplayName("Naziv predmeta")]
        public string Naziv { get; set; }

        [DisplayName("Opis predmeta")]
        public string Opis { get; set; }
    }
}
