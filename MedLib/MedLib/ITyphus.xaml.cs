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
    public partial class ITyphus : ContentPage
    {
        Infection typhus;
        public ITyphus()
        {
            InitializeComponent();
            Infection qwe = new Infection();
            typhus = new Infection("Typhous", "Symptoms include severe headache, a sustained high fever, cough, rash, severe muscle pain, chills, " +
            "falling blood pressure, stupor, sensitivity to light, delirium and death. A rash begins on the chest about five days after the fever appears," +
            " and spreads to the trunk and extremities. A symptom common to all forms of typhus is a fever which may reach 39 °C (102 °F). "
            , 1, 1, 20, 10);
            L1.Text = typhus.Name;
            Start();
     
        }

        public Infection Start()
        {
            Infection qwe = new Infection();
            return qwe;
        }
        



        // label.Text = string.Format("name {0}", typhus.Name.get);
        /*
                void Button_Clicked(object sender, EventArgs e)
                {
                    Mental bipolar = new Mental("Not a Bipolar disorder", "Bipolar disorder, previously known as manic depression, is a mental disorder that causes periods of depression and periods of abnormally elevated mood."
                        , 1, 20, 20, 20);

                    DisplayAlert(bipolar.Name, "You're not great", "Ok");
                }
                */


    }
}