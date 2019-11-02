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
    public partial class CPage : ContentPage
    {

        LibraryGenetic LG;
        LibraryInfection LI;
        LibraryMental LM;
        Options op;
        public int c = 0;
        public CPage(LibraryGenetic _LG, LibraryInfection _LI, LibraryMental _LM, int a, Options _op)
        {
            LG = _LG;
            LI = _LI;
            LM = _LM;
            c = a;
            op = _op;
            InitializeComponent();
            B1.Text = op.find;
            B2.Text = op.add;
            B3.Text = op.view;
            label.Text = op.s1;
        }
        //men gen inf
 
        private void Button_Clicked1(object sender, EventArgs e) //find
        {
            Navigation.PushAsync(new SearchPage(LG, LI, LM, op));

        }

        private void Button_Clicked2(object sender, EventArgs e) //add
        {
            if(c ==1)
            {
                Navigation.PushAsync(new AddMental(LM, op));
            }
            else if(c ==2)
            {
                Navigation.PushAsync(new Add(LG, op));
            }
            else
            {
                Navigation.PushAsync(new AddInf(LI, op));
            }

        }

        private void Button_Clicked3(object sender, EventArgs e) //view
        {
            Navigation.PushAsync(new WList(LG, LI, LM, c, op));
        }
       
    
    }
}