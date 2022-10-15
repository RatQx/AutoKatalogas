using System.ComponentModel.DataAnnotations;

namespace AutoKatalogas.Models
{
    public class Dalys
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string? Name { get; set; }

        [StringLength(32)]
        public string? Material { get; set; }

        [StringLength(64)]
        public string? Placement { get; set; }

        public int? AutomobilioId { get; set; }
    }
    public class DalysCreateReq
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string? Name { get; set; }

        [StringLength(32)]
        public string? Material { get; set; }

        [StringLength(64)]
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

