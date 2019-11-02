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
	public partial class AddMental : ContentPage
	{
        Options op;
        LibraryMental LM;
        public AddMental(LibraryMental _LM, Options _op)
		{
            LM = _LM;
			InitializeComponent ();
            op = _op;

            Name.Label = op.name;
            Name.Placeholder = op.iname;
            Prev.Label = op.prevalence;
            Prev.Placeholder = op.iprevalence;
            Dev.Label = op.development;
            Dev.Placeholder = op.idevelopment;
            Age.Label = op.age;
            Age.Placeholder = op.iage;           
            WTF.Label = op.wtf;
            WTF.Placeholder = op.iwtf;
            Sec1.Title = op.addD;
            Sec2.Title = op.GD;
            Sec3.Title = op.im;
            B1.Text = op.save;

        }


        async private void Click(object sender, EventArgs e)
        {
            Mental node = new Mental();

                //Genetic node = new Genetic();
                node.Name = Name.Text;
                node.Development = Dev.Text;
                node.Prevalence = Convert.ToInt32(Prev.Text);
                node.Age = Convert.ToInt32(Age.Text);
 
            LM.mental.Add(node);
            List<Mental> buffer = LM.mental;
            var sortedlist = from u in buffer orderby u.Name select u;
            List<Mental> newg = new List<Mental>();
            foreach (Mental g in sortedlist)
            {
                newg.Add(g);
            }
            LM.mental = newg;

            //запись в файл 
            // new Genetic Klinefelter = new Genetic()
            DataContractJsonSerializer jsonFormat = new DataContractJsonSerializer(typeof(List<Mental>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/MName.json", FileMode.Create))
            {
                jsonFormat.WriteObject(fs, LM.mental);
            }
            //считывание
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Mental>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/MName.json", FileMode.Open))
            {
                LM.mental = (List<Mental>)jsonSerializer.ReadObject(fs);
            }

            await Navigation.PopAsync();
        }
    }

}