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
	public partial class GreetPage : ContentPage
	{
        LibraryGenetic LG;
        LibraryInfection LI;
        LibraryMental LM;
        Options op;
        public GreetPage (LibraryGenetic _LG, LibraryInfection _LI, LibraryMental _LM, Options _op)
		{
            LG = _LG;
            LI = _LI;
            LM = _LM;
			InitializeComponent ();
            op = _op;
            B1.Text = op.ment;
            B2.Text = op.gen;
            B3.Text = op.inf;
            l1.Text = op.l1;
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
           
            Navigation.PushAsync(new CPage(LG, LI, LM, 1, op));
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new CPage(LG, LI, LM, 2, op));
        }

        private void Button_Clicked3(object sender, EventArgs e)
        {
           
            Navigation.PushAsync(new CPage(LG, LI, LM, 3, op));
        }

    }
}