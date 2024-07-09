namespace Pets.WebApi.Models
{
    public class GetAllByPriceRequest
    {
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }
    }
}
