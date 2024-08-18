using System.Collections.ObjectModel;
using ClothFashionApp.Services.FakeEndpoints;

namespace ClothFashionApp.Presentation;

public partial class HomeViewModel : ObservableObject
{
    Promotion _promotion;
    ObservableCollection<string> _categories;
    ObservableCollection<Product> _popularProducts;

    readonly IClothFashionService _clothFashionService;
    readonly INavigator _navigator;

    public HomeViewModel(
        IOptions<AppConfig> appInfo,
        IClothFashionService clothFashionService,
        INavigator navigator)
    {
        _clothFashionService = clothFashionService;
        _navigator = navigator;

        LoadData();
    }

    public Promotion Promotion
    {
        get { return _promotion; }
        set
        {
            _promotion = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<string> Categories
    {
        get { return _categories; }
        set
        {
            _categories = value;
            OnPropertyChanged();
        }
    }

    [ObservableProperty]
    string selectedCategory;

    public ObservableCollection<Product> PopularProducts
    {
        get { return _popularProducts; }
        set
        {
            _popularProducts = value;
            OnPropertyChanged();
        }
    }

    void LoadData()
    {
        Promotion = _clothFashionService.GetPromotion();
        Categories = new ObservableCollection<string>(_clothFashionService.GetCategories());
        SelectedCategory = Categories.FirstOrDefault();
        PopularProducts = new ObservableCollection<Product>(_clothFashionService.GetPopularProducts());
    }
}
