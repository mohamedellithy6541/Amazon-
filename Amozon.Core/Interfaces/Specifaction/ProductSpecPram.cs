namespace Amozon.Core.Interfaces.Specifaction
{
    public class ProductSpecificationPram
    {
        private const int Maxpagesize = 10;
        private int pageSize =  5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > Maxpagesize ? Maxpagesize : value; }
        }
        public int PageIndex { get; set; }
        public string? sort { get; set; }
        public int? BranId { get; set; }
        public int? TypeId { get; set; }
    }
}
