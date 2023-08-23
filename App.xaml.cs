using Recipe.View;
using Recipe.View.MyFlyoutPage;
using Recipe.View.NavPages;
using Recipe.View.RecipeTabbedPage;
using Recipe.ViewModels;

namespace Recipe;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new NavigationPage(new NavPageHome());
		//      MainPage.BackgroundColor = Color.FromArgb("#FCFCFC");
		//NavigationPage.BarTextColor = Color.White;

#if ANDROID || IOS
		MainPage = new RecipeTabbedPage();
#else
        MainPage = new MyFlyoutPage();
#endif
        BindingContext = new CookBookViewModel();
    }


}
