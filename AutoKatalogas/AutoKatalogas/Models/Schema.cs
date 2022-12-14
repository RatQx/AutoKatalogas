using System;
namespace AutoKatalogas.Models
{
    public class Schema
    {
        public int Id { get; set; }
        public string? Img { get; set; }

        public int? AprasymasId { get; set; }
        //public Aprasymas? aprasymas { get; }
    }

    public class SchemaCreateReq
    {
        public int Id { get; set; }
        public string? Img { get; set; }

        public int? AprasymasId { get; set; }

        public Schema ToSchema() => new()
        {
            Id = Id,
            Img = Img,
            AprasymasId = AprasymasId
        };
    }
}
