namespace Recipe.View.NavPages;

public partial class NavPageHome : ContentPage
{
	public NavPageHome()
	{
		InitializeComponent();
	}

    private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Home()); // d�clench� lorsqu�une page est pouss�e vers la pile de navigation.
    }

    private async void CookBookButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CookBook());
	}
}