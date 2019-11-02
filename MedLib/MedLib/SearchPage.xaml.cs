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
    public partial class SearchPage : ContentPage
    {
        Options op;
        LibraryGenetic LG;
        LibraryInfection LI;
        LibraryMental LM;
        public SearchPage(LibraryGenetic _LG, LibraryInfection _LI, LibraryMental _LM, Options _op)
        {
            LG = _LG;
            LI = _LI;
            LM = _LM;
            op = _op;
            InitializeComponent();
            Search.Placeholder = op.name;
            B.Text = op.search;
        }

        private async void Click(object sender, EventArgs e)
        {
            bool found = false;
            string Name = Search.Text;
            foreach(Genetic g in LG.genetic)
            {
                if (Name == g.Name)
                {
                    found = true;
                    await DisplayAlert(g.Name, "Development: " + g.Development + "\n" + "Age: " + g.Age + "\n" + "Prevalence: " + g.Prevalence + "\nSeverity: " + g.Severity
                     + "\nProp of inhertance from Mom: " + g.PropOfInheritanceMom + "\nProp of inhertance from Dad: " + g.PropOfInheritanceDad + "\nProp of inhertance: " + g.PropOfInheritance, "OK");
                    break;
                }
            }
            if (!found) {
                foreach (Mental m in LM.mental)
                {
                    if (Name == m.Name)
                    {
                        await DisplayAlert(m.Name, "Development: " + m.Development + "\n" + "Age: " + m.Age + "\n" + "Prevalence: " + m.Prevalence, "OK");

                        found = true;
                        break;
                        
                    }
                }
            }
            if (!found)
            {
                foreach (Infection g in LI.infection)
                {
                    if (Name == g.Name)
                    {
                        await DisplayAlert(g.Name, "Development: " + g.Development + "\n" + "Age: " + g.Age + "\n" + "Prevalence: " + g.Prevalence + "\nSeverity: " + g.Severity
                    + "\nIncubation Period: " + g.IncubationPeriod, "OK");
                        found = true;
                        break;
                        
                    }
                }
            }
            if(!found)
            { await DisplayAlert("404", "Not Found ", "OK("); }
            //Navigation.PushAsync(new GreetPage(LG, LI, LM));
        }

    }
}