using Recipe.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services
{
    internal class RecipeApiService
    {
        private readonly HttpClient _httpClient;
        
        public RecipeApiService()
        {
            _httpClient = new HttpClient(); // Good practice => instantiate it only once during the application lifespan
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL); // Assign the base api url
            
        }

        public async Task<RecipeAPIResponse> GetRandomRecipe() // Get random recipe and insert the response on the RecipeAPIResponse class
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            return await _httpClient.GetFromJsonAsync<RecipeAPIResponse>($"{Constants.API_RECIPE_RANDOM}?apiKey={Constants.API_KEY}&{Constants.API_RECIPE_RANDOM_NUMBER}=1");
        }
        
        public async Task<RecipeAPIResponse> GetRecipeBySearch(string search)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            return await _httpClient.GetFromJsonAsync<RecipeAPIResponse>($"{Constants.API_RECIPE_SEARCH}?{Constants.API_RECIPE_SEARCH_QUERY}={search}&apiKey={Constants.API_KEY}");
        }

        //public async Task<RecipeAPIResponse> Get
    }
}