 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedLib
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Add : ContentPage
	{
        Options op;
        LibraryGenetic LG;
        public Add(LibraryGenetic _LG, Options _op)
        {
            LG = _LG;     
            InitializeComponent();
            op = _op;

            Name.Label = op.name;
            Name.Placeholder = op.iname;
            Prev.Label = op.prevalence;
            Prev.Placeholder = op.iprevalence;
            Dev.Label = op.development;
            Dev.Placeholder = op.idevelopment;
            Age.Label = op.age;
            Age.Placeholder = op.iage;
            Sev.Label = op.severity;
            Sev.Placeholder = op.iseverity;
            Mom.Label = op.mom;
            Dad.Label = op.dad;
            Gen.Label = op.inh;
            WTF.Label = op.wtf;
            WTF.Placeholder = op.iwtf;
            Sec1.Title = op.addD;
            Sec2.Title = op.GD;
            Sec3.Title = op.tinh;
            Sec4.Title = op.im;
            B1.Text = op.save;

            //FontSize = 19       
        }

        async private void Click(object sender, EventArgs e)
        {
            Genetic node = new Genetic();
           
            node.Name = Name.Text;
            node.Development = Dev.Text;
            node.Prevalence = Convert.ToInt32(Prev.Text);
            node.Severity = Convert.ToInt32(Sev.Text);
            node.Age = Convert.ToInt32(Age.Text);
            node.PropOfInheritanceMom = Convert.ToInt32(Mom.Text);
            node.PropOfInheritanceDad = Convert.ToInt32(Dad.Text);
            node.PropOfInheritance = Convert.ToInt32(Gen.Text);
            
            LG.genetic.Add(node);
            List<Genetic> buffer = LG.genetic;
            var sortedlist = from u in buffer orderby u.Name select u;
            List<Genetic> newg = new List<Genetic>();
            foreach(Genetic g in sortedlist)
            {
                newg.Add(g);
            }
            LG.genetic = newg;

            //запись в файл 
            // new Genetic Klinefelter = new Genetic()
            DataContractJsonSerializer jsonFormat = new DataContractJsonSerializer(typeof(List<Genetic>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/GName.json", FileMode.Create))
            {
                jsonFormat.WriteObject(fs, LG.genetic);
            }
            //считывание
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Genetic>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/GName.json", FileMode.Open))
            {
                LG.genetic = (List<Genetic>)jsonSerializer.ReadObject(fs);
            }

            await Navigation.PopAsync();
        }
    }



}