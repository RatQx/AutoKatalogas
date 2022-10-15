using System.ComponentModel.DataAnnotations;

namespace AutoKatalogas.Models
{
    public class Aprasymas
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string? Name { get; set; }

        [StringLength(32)]
        public string? Type { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public int? DalisId { get; set; }

    }

    public class AprasymasCreateReq
    {
        public int Id { get; set; }

        [StringLength(32)]
        public string? Name { get; set; }

        [StringLength(32)]
        public string? Type { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public int? DalisId { get; set; }

        public Aprasymas ToAprasymas() => new()
        {
            Id = Id,
            Name = Name,
            Type = Type,
            Description = Description,
            DalisId = DalisId,
        };
    }
}
