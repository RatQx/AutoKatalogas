using System.ComponentModel.DataAnnotations;

namespace AutoKatalogas.Models
{
    public class Aprasymas
    {
        public int Id { get; set; }

        [StringLength(32, ErrorMessage = "Description name length can't be longer then 32 characters.")]
        public string? Name { get; set; }

        [StringLength(32, ErrorMessage = "Description type length can't be longer then 32 characters.")]
        public string? Type { get; set; }

        [StringLength(1000, ErrorMessage = "Description length can't be longer then 1000 characters.")]
        public string? Description { get; set; }

        public int? DalisId { get; set; }

    }

    public class AprasymasCreateReq
    {
        public int Id { get; set; }

        [StringLength(32, ErrorMessage = "Description name length can't be longer then 32 characters.")]
        public string? Name { get; set; }

        [StringLength(32, ErrorMessage = "Description type length can't be longer then 32 characters.")]
        public string? Type { get; set; }

        [StringLength(1000, ErrorMessage = "Description length can't be longer then 1000 characters.")]
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
