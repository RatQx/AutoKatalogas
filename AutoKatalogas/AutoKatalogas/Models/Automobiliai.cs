using AutoKatalogas.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace AutoKatalogas.Models
{
    public class Automobiliai : IUserOwnedResource
    {
        public int id { get; set; }

        [StringLength(18, ErrorMessage = "Vin length can't be longer then 18 characters.")]
        public string? Vin { get; set; }

        [StringLength(32, ErrorMessage = "Model length can't be longer then 32 characters.")]
        public string? Model { get; set; }

        [StringLength(32, ErrorMessage = "Marke length can't be longer then 32 characters.")]
        public string? Marke { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Production Date")]
        public DateTime? Production_date { get; set; }

        [Required]
        public string UserId { get; set; }
        public ForumRestUser User { get; set; }

        public class AutomobiliaiCreateReq
        {
            public int id { get; set; }

            [StringLength(18, ErrorMessage = "Vin length can't be longer then 18 characters.")]
            public string? Vin { get; set; }

            [StringLength(32, ErrorMessage = "Model length can't be longer then 32 characters.")]
            public string? Model { get; set; }

            [StringLength(32, ErrorMessage = "Marke length can't be longer then 32 characters.")]
            public string? Marke { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "Production Date")]
            public DateTime? Production_date { get; set; }

            public Automobiliai ToAutomobiliai() => new()
            {
                id= id,
                Vin = Vin,
                Marke = Marke,
                Production_date = Production_date,
                Model=Model
            };
        }
    }
}
