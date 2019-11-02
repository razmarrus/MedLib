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
	public partial class WList : ContentPage
	{
        Options op;
        LibraryGenetic LG;
        LibraryInfection LI;
        LibraryMental LM;
        int c;
		public WList (LibraryGenetic _LG, LibraryInfection _LI, LibraryMental _LM, int a, Options _op)
		{
            LG = _LG;
            LI = _LI;
            LM = _LM;
            c = a;
            op = _op;
			InitializeComponent ();
            if (a == 1)
            {
                ListView listView = new ListView
                {

                    HasUnevenRows = true,
                    ItemsSource = LM.mental,
                    Margin = 10,
                    ItemTemplate = new DataTemplate(() =>
                    {
                        ImageCell imageCell = new ImageCell { TextColor = Color.Violet, DetailColor = Color.LemonChiffon };
                        imageCell.SetBinding(TextCell.TextProperty, "Name");
                        //  Binding fbinding = new Binding { Path = "Development" };
                        imageCell.SetBinding(ImageCell.ImageSourceProperty, "WayToPhoto");
                        Image Image1 = new Image();
                        //Image1.Source = ImageSource.FromUri(new Uri(""));
                        Image1.Source = ImageSource.FromResource("MedLib.Insomia.jpg");
                        Image1.Aspect = Aspect.AspectFit;

                        imageCell.Height = 100;
                        return imageCell;
                    })
                };
                listView.ItemTapped += OnItemTapped;
                this.Content = new StackLayout { Children = { listView } };
            }
            else if (a == 2)
            {
                ListView listView = new ListView
                {
                    HasUnevenRows = true,
                    ItemsSource = LG.genetic,
                    Margin = 10,
                    ItemTemplate = new DataTemplate(() =>
                    {

                        ImageCell imageCell = new ImageCell { TextColor = Color.Violet, DetailColor = Color.LightSteelBlue };
                        imageCell.SetBinding(TextCell.TextProperty, "Name");
                        //  Binding fbinding = new Binding { Path = "Development" };
                        imageCell.SetBinding(ImageCell.ImageSourceProperty, "WayToPhoto");
                        imageCell.Height = 100;
                        return imageCell;
                     
                    })
                };
                listView.ItemTapped += OnItemTapped;
                this.Content = new StackLayout { Children = { listView } };
            }
            else
            {
                ListView listView = new ListView
                {
                    HasUnevenRows = true,
                    ItemsSource = LI.infection,
                    Margin = 10,
                    ItemTemplate = new DataTemplate(() =>
                    {

                        ImageCell imageCell = new ImageCell { TextColor = Color.Violet, DetailColor = Color.LemonChiffon };
                        imageCell.SetBinding(TextCell.TextProperty, "Name");
                        //  Binding fbinding = new Binding { Path = "Development" };
                        imageCell.SetBinding(ImageCell.ImageSourceProperty, "WayToPhoto");
                        imageCell.Height = 100;
                        return imageCell;

                    })
                };
                listView.ItemTapped += OnItemTapped;
                this.Content = new StackLayout { Children = { listView } };
            }
		}

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (c == 1)
            {
                Mental g = e.Item as Mental;
                await DisplayAlert(g.Name, op.development + ": " + g.Development + "\n" + op.age + ": " + g.Age + "\n" + op.prevalence + ": " + g.Prevalence + "%\n", "OK");
            }
            else if (c == 2) {
                Genetic g = e.Item as Genetic;
                await DisplayAlert(g.Name, op.development + ": "+ g.Development + "\n" + op.age+ ": " + g.Age + "\n" + op.prevalence  + ": " + g.Prevalence + "%\n"+ op.severity + ": " + g.Severity
                    +"%\n" + op.mom + ": " + g.PropOfInheritanceMom + "%\n" + op.dad + ": " + g.PropOfInheritanceDad + "%\n" + op.inh + ": " + g.PropOfInheritance + "%", "OK");
                //(g.Name, "\n", op.development + g.Development + "\n" + op.age + g.Age + "\n" + op.prevalence + g.Prevalence + "\n"+ op.severity + g.Severity
               // +"\n" + op.mom + g.PropOfInheritanceMom + "\n" + c + g.PropOfInheritanceDad + "\n" + op.inh + g.PropOfInheritance, "OK");

            }
            else if (c == 3)
            {
                Infection g = e.Item as Infection;
                await DisplayAlert(g.Name, op.development + ": " + g.Development + "\n" + op.age + ": " + g.Age + "\n" + op.prevalence + ": " + g.Prevalence + "%\n" + op.severity + ": " + g.Severity
                    + "%\n" + op.incub + ": " + g.IncubationPeriod, "OK");
            }
            //ссылка на страницу
            // DisplayAlert("Found", .Development + "\n" + m.Age + "\n" + m.Prevalence, "OK");
        }
	}
}