namespace Orders.Model
{
    public class Stitching
    {
        public int StitchingId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }

    }
}
