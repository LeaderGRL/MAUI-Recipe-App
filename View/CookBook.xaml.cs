namespace Recipe.View;

public partial class CookBook : ContentPage
{
	public CookBook()
	{
		InitializeComponent();
    }
    private async void CloseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); //est d�clench� lorsqu�une page est extraite de la pile de navigation.
    }
}