namespace FlowerSales.Models
{
    public class ProductQueryParameters: QueryParameters
    {
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public bool? IsAvialable { get; set; }
    }
}
