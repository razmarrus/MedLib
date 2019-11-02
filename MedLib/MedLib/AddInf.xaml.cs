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
	public partial class AddInf : ContentPage
	{
        Options op;
        LibraryInfection LI;
        public AddInf (LibraryInfection _LI, Options _op)
		{
            op = _op;
            LI = _LI;
			InitializeComponent ();

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
            WTF.Label = op.wtf;
            WTF.Placeholder = op.iwtf;
            Sec1.Title = op.addD;
            Sec2.Title = op.GD;
            Sec3.Title = op.im;
            Inc.Label = op.incub;
            Inc.Placeholder = op.iincub;
            B1.Text = op.save;
        }
	
 
        async private void Click(object sender, EventArgs e)
        {
            Infection node = new Infection();
            node.Name = Name.Text;
            node.Development = Dev.Text;
            node.Prevalence = Convert.ToInt32(Prev.Text);
            node.Severity = Convert.ToInt32(Sev.Text);
            node.Age = Convert.ToInt32(Age.Text);
    
        
            LI.infection.Add(node);
            List<Infection> buffer = LI.infection;
            var sortedlist = from u in buffer orderby u.Name select u;
            List<Infection> newg = new List<Infection>();
            foreach (Infection g in sortedlist)
            {
                newg.Add(g);
            }
            LI.infection = newg;

            //запись в файл 
            // new Genetic Klinefelter = new Genetic()
            DataContractJsonSerializer jsonFormat = new DataContractJsonSerializer(typeof(List<Infection>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/IName.json", FileMode.Create))
            {
                jsonFormat.WriteObject(fs, LI.infection);
            }
            //считывание
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Infection>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/IName.json", FileMode.Open))
            {
                LI.infection = (List<Infection>)jsonSerializer.ReadObject(fs);
            }

            await Navigation.PopAsync();
        }
    }

}