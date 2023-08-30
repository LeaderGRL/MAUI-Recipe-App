namespace Recipe.View.MyFlyoutPage;

public partial class RecipeDetail : ContentView
{
	public RecipeDetail()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(RecipeDetail));
    public string Name
    {
        get => GetValue(NameProperty) as string;
        set => SetValue(NameProperty, value);
    }
}
