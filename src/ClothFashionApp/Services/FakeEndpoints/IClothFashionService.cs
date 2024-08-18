namespace ClothFashionApp.Services.FakeEndpoints;

public interface IClothFashionService
{
    IEnumerable<Item> GetPromoItems();
    IEnumerable<string> GetCategories();
    Promotion GetPromotion();
    IEnumerable<Product> GetPopularProducts();
}
