using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIN_Projekt.Models
{
    public class Studenti
    {

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Ime { get; set; }

        [Required]
        [StringLength(10)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(13)]
        [DisplayName("OIB")]
        public string Oib { get; set; }

        [DisplayName("Datum rođenja")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime DatumRod { get; set; }

        [DisplayName("Mjesto rođenja")]
        public string MjestoRod { get; set; }
        
        [StringLength(30)]
        public string Adresa { get; set; }

    }
}
