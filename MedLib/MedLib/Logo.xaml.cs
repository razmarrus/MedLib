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
    public partial class Logo : ContentPage
    {

        public Logo()
        {
            InitializeComponent();
            Im.Source = ImageSource.FromResource("MedLib.Log.png");
            Im.Aspect = Aspect.AspectFit;
            Im.RotateTo(360, 2000);
            Im.Rotation = 0;
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FPage());
        }
        
    }
}