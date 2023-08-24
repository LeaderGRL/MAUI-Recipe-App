using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipe.Models;
using Recipe.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.ViewModels
{
    public partial class CookBookViewModel
    {
        private readonly RecipeApiService _RecipeApiService;

        private RecipeHandler _recipeHandler;
        private System.Timers.Timer _debounceTimer;
        private string _keyword;

        public ObservableCollection<RecipeItem> RecipeList => _recipeHandler.RecipeList; // Return the list of recipe to the view

        public CookBookViewModel()
        {
            _RecipeApiService = new RecipeApiService();
            _recipeHandler = new RecipeHandler();
            CallRandomRecipeAPI();
        }

        private async void CallRandomRecipeAPI()
        {
            await FetchRandomRecipeInformation();
        }
        
        

        [RelayCommand] // When event is trigger, call the associeted method in the view model
        private async Task FetchRandomRecipeInformation()
        {
            var randomRecipeApiResponse = await _RecipeApiService.GetRandomRecipe();
            if (randomRecipeApiResponse != null)
            {
                //Debug.WriteLine("Image : " + randomRecipeApiResponse.recipes[0].image);
                _recipeHandler.Add(new RecipeItem(randomRecipeApiResponse.recipes[0].image, randomRecipeApiResponse.recipes[0].title, randomRecipeApiResponse.recipes[0].summary));

                //for (int i = 0; i < Constants.API_RECIPE_NUMBER_OF_RECIPE; i++)
                //{
                //    _recipeHandler.Add(new RecipeItem(randomRecipeApiResponse.recipes[i].image, randomRecipeApiResponse.recipes[i].title, randomRecipeApiResponse.recipes[i].summary));
                //}
                //ImageURL = randomRecipeApiResponse.recipes[0].image;
                //Title = randomRecipeApiResponse.recipes[0].title;
                //Summary = randomRecipeApiResponse.recipes[0].summary;
            }
        }

        private async Task FetchRecipeBySearch(string search)
        {
            var recipeBySearch = await _RecipeApiService.GetRecipeBySearch(search);

            if(recipeBySearch != null)
            {
                for (int i = 0; i < Constants.API_RECIPE_NUMBER_OF_RECIPE; i++)
                {
                    _recipeHandler.Add(new RecipeItem(recipeBySearch.recipes[i].image, recipeBySearch.recipes[i].title, recipeBySearch.recipes[i].summary));
                }
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _keyword = e.NewTextValue;
            if (string.IsNullOrEmpty(_keyword))
            {
                
            }
            else
            {
                RecipeList.Clear();
                DebounceSearch(300);
            }
        }

        private void DebounceSearch(int timer) // Delay the API querry when the user type on the search bar
        {
            if (_debounceTimer != null)
            {
                _debounceTimer.Stop();
                _debounceTimer.Elapsed -= OnDebounceElapsed;

            }
            else
            {
                _debounceTimer = new System.Timers.Timer(timer);
                _debounceTimer.Elapsed += OnDebounceElapsed;
                _debounceTimer.Start();
            }
           
        }

        private void OnDebounceElapsed(object sender, EventArgs e) // Event trigger when the timer is elapsed
        {
            _debounceTimer.Stop();
            _debounceTimer.Elapsed -= OnDebounceElapsed;

            SearchList(_keyword);
        }

        private async void SearchList(string keyword)
        {

            //var RecipeSearch = RecipeList.Where(x => x.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList(); 
            var recipeSearch = await _RecipeApiService.GetRecipeBySearch(_keyword);

            if (recipeSearch != null)
            {
                for (int i = 0; i < Constants.API_RECIPE_NUMBER_OF_RECIPE; i++)
                {
                    _recipeHandler.Add(new RecipeItem(recipeSearch.recipes[i].image, recipeSearch.recipes[i].title, recipeSearch.recipes[i].summary));
                }
            }
        }
    }

    public class RecipeHandler
    {
        public ObservableCollection<RecipeItem> RecipeList { get; private set; } // ObservableCollection is a list that can be update by UI notification

        public RecipeHandler()
        {
            RecipeList = new ObservableCollection<RecipeItem>();
        }
        
        public void Add(RecipeItem recipeItem)
        {
            RecipeList.Add(recipeItem);
        }
    }

    
    //public partial class RecipeItem : ObservableObject
    //{
    //    [ObservableProperty]
    //    public String imageURL;

    //    [ObservableProperty]
    //    private String title;

    //    [ObservableProperty]
    //    private String summary;

    //    public RecipeItem(String imageURL, String title, String summary)
    //    {
    //        ImageURL = imageURL;
    //        Title = title;
    //        Summary = summary;
    //    }
    //}
}