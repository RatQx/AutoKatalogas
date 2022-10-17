using System.ComponentModel.DataAnnotations;

namespace AutoKatalogas.Models
{
    public class Dalys
    {
        public int Id { get; set; }

        [StringLength(32, ErrorMessage = "Part name length can't be longer then 32 characters.")]
        public string? Name { get; set; }

        [StringLength(18, ErrorMessage = "Material length can't be longer then 32 characters.")]
        public string? Material { get; set; }

        [StringLength(64, ErrorMessage = "Placement length can't be longer then 64 characters.")]
        public string? Placement { get; set; }

        public int? AutomobilioId { get; set; }

        //public Automobiliai? automobiliai { get; }
    }
    public class DalysCreateReq
    {
        public int Id { get; set; }

        [StringLength(32, ErrorMessage = "Part name length can't be longer then 32 characters.")]
        public string? Name { get; set; }

        [StringLength(18, ErrorMessage = "Material length can't be longer then 32 characters.")]
        public string? Material { get; set; }

        [StringLength(64, ErrorMessage = "Placement length can't be longer then 64 characters.")]
        public string? Placement { get; set; }

        public int? AutomobilioId { get; set; }

        public Dalys ToDalys() => new()
        {
            Id = Id,
            Name = Name,
            Material = Material,
            Placement = Placement,
            AutomobilioId = AutomobilioId
        };
    }


}

