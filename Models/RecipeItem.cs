using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Models
{
    public partial class RecipeItem : ObservableObject
    {
        [ObservableProperty]
        public String imageURL;

        [ObservableProperty]
        public String title;

        [ObservableProperty]
        public String summary;

        public RecipeItem(String imageURL, String title, String summary)
        {
            ImageURL = imageURL;
            Title = title;
            Summary = summary;
        }
    }
}
