namespace FlowerSales.Models
{
    public class QueryParameters
    {
        // for searching
        const int _maxSize = 100;
        private int _size = 50;

        public int Size 
        { 
            get { return _size; } 
            set { _size = Math.Min(_maxSize,value); }
        }

        public int Page { get; set; } = 1;

        // for sorting
        private string _sortOrder = "asc";
        public string SortOrder
        {
            get { return _sortOrder; }
            set
            {
                if (value == "asc" || value == "desc") { _sortOrder = value; }
            }
        }
        public string SortBy { get; set; } = "ProductId";
    }
}
