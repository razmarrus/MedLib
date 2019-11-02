using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedLib
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartInfo : ContentPage
	{
        public StartInfo()
        {
           // InitializeComponent()

            Title = "Main Page";
            Button toCommonPageBtn = new Button
            {
                Text = "To greet page",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout { Children = { toCommonPageBtn } };

        }

        private async void ToCommonPage(object sender, EventArgs e)
        {
          //  await Navigation.PushAsync(new GreetPage());
        }

    }
}