using System.ComponentModel.DataAnnotations;

namespace s17_l3.Models
{
    public class Scarpa
    {
        public int ID { get; set; }

        public string? Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Prezzo { get; set; }

        public string? Descrizione { get; set; }
    }
}
