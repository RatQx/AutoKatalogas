using System.ComponentModel.DataAnnotations;

namespace AutoKatalogas.Models
{
    public class Automobiliai
    {
        public int id { get; set; }

        [StringLength(18)]
        public string? Vin { get; set; }

        [StringLength(32)]
        public string? Model { get; set; }

        [StringLength(32)]
        public string? Marke { get; set; }

        public DateTime? Prodiction_date { get; set; } // add checks for date and normal format.


    }
}
