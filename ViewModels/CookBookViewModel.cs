using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipe.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.ViewModels
{
    public partial class CookBookViewModel : ObservableObject
    {
        private readonly RecipeApiService _RecipeApiService;

        public CookBookViewModel()
        {
            _RecipeApiService = new RecipeApiService();
            CallRandomRecipeAPI();
        }

        private async void CallRandomRecipeAPI()
        {
            await FetchRandomRecipeInformation();
        }
        
        [ObservableProperty] // Generate code for our property to notify the UI when it changes
        private String imageURL;

        [ObservableProperty]
        private String title;

        [ObservableProperty]
        private String summary;

        [RelayCommand] // When event is trigger, call the associeted method in the view model
        private async Task FetchRandomRecipeInformation()
        {
            var randomRecipeApiResponse = await _RecipeApiService.GetRandomRecipe();
            if (randomRecipeApiResponse != null)
            {
                ImageURL = randomRecipeApiResponse.recipes[0].image;
                Title = randomRecipeApiResponse.recipes[0].title;
                Summary = randomRecipeApiResponse.recipes[0].summary;
            }
            Debug.WriteLine("Fetch API !");
        }

        private void CookBook_Loaded(object sender, EventArgs e)
        {

        }
    }
}