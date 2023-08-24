﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        //[ObservableProperty] // Generate code for our property to notify the UI when it changes
        //private String imageURL;

        //[ObservableProperty]
        //private String title;

        //[ObservableProperty]
        //private String summary;

        private RecipeHandler _recipeHandler;
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
                //_recipeHandler.Add(new RecipeItem(randomRecipeApiResponse.recipes[0].image, randomRecipeApiResponse.recipes[0].title, randomRecipeApiResponse.recipes[0].summary));

                for (int i = 0; i < Constants.API_RECIPE_NUMBER_OF_RECIPE; i++)
                {
                    _recipeHandler.Add(new RecipeItem(randomRecipeApiResponse.recipes[i].image, randomRecipeApiResponse.recipes[i].title, randomRecipeApiResponse.recipes[i].summary));
                }
                //ImageURL = randomRecipeApiResponse.recipes[0].image;
                //Title = randomRecipeApiResponse.recipes[0].title;
                //Summary = randomRecipeApiResponse.recipes[0].summary;
            }
        }

        public ObservableCollection<RecipeItem> RecipeList => _recipeHandler.RecipeList;

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

    public partial class RecipeItem : ObservableObject
    {
        [ObservableProperty]
        public String imageURL;

        [ObservableProperty]
        private String title;

        [ObservableProperty]
        private String summary;

        public RecipeItem(String imageURL, String title, String summary)
        {
            ImageURL = imageURL;
            Title = title;
            Summary = summary;
        }
    }
}