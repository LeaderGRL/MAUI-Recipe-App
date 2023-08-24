using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Recipe
{
    internal class Constants
    {
        public const string API_KEY = "63545f6766ff4238a36a974f0a9b741d";
        public const string API_BASE_URL = "https://api.spoonacular.com/recipes/";
        public const string API_RECIPE_SEARCH = "complexSearch";
        public const string API_RECIPE_SEARCH_QUERY = "query";
        public const string API_RECIPE_INFO = "{0}/information";
        public const string API_RECIPE_INGREDIENTS = "{0}/ingredientWidget.json";
        public const string API_RECIPE_ANALYZE = "{0}/analyzeInstructions";
        public const string API_RECIPE_RANDOM = "random";
        public const string API_RECIPE_RANDOM_NUMBER = "number";
        public const string API_RECIPE_SIMILAR = "{0}/similar";
        public const string API_RECIPE_SUMMARY = "{0}/summary";
        public const string API_RECIPE_EQUIPMENT = "{0}/equipmentWidget.json";
        public const string API_RECIPE_PRICE_BREAKDOWN = "{0}/priceBreakdownWidget.json";
        public const string API_RECIPE_NUTRITION = "{0}/nutritionWidget.json";
        public const string API_RECIPE_TODAY = "https://api.spoonacular.com/recipes/random";
        public const string API_RECIPE_SEARCH_BY_INGREDIENTS = "findByIngredients";
        public const string API_RECIPE_SEARCH_BY_NUTRIENTS = "findByNutrients";
        public const string API_RECIPE_SEARCH_BY_INGREDIENTS_AND_NUTRIENTS = "findByIngredients,findByNutrients";
        public const string API_RECIPE_SEARCH_BY_INGREDIENTS_OR_NUTRIENTS = "findByIngredients,findByNutrients";
        public const string API_RECIPE_SEARCH_BY_INGREDIENTS_AND_NUTRIENTS_AND_CUISINE = "findByIngredients,findByNutrients,findByCuisine";
        public const string API_RECIPE_SEARCH_BY_INGREDIENTS_OR_NUTRIENTS_AND_CUISINE = "findByIngredients,findByNutrients,findByCuisine";
        public const string API_RECIPE_SEARCH_BY_INGREDIENTS_AND_NUTRIENTS_AND_CUISINE_AND_TYPE = "findByIngredients,findByNutrients,findByCuisine,findByType";
        public const int API_RECIPE_NUMBER_OF_RECIPE = 5;
    }
}
