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
    public partial class FPage : ContentPage
    {
        LibraryGenetic LG;
        LibraryInfection LI;
        LibraryMental LM;
        Options op;
        
        public FPage()
        {
            
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Options));
               using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/op.json", FileMode.Open))
               {
                   op = (Options)jsonSerializer.ReadObject(fs);
               }
           // op = new Options("English");
            InitializeComponent();
            
           
            LG = new LibraryGenetic();
            LI = new LibraryInfection();
            LM = new LibraryMental();

            /*LI.infection.Add(new Infection("typhus.jpg","Typus", " group of infectious diseases that include epidemic typhus, scrub typhus and murine typhus.Common symptoms include fever, headache, and a rash.", 10, 10,10, 10));
            LI.infection.Add(new Infection("Lassa.jpg","Lassa virus", " viral hemorrhagic fever (VHF), in humans and other primates. Lassa virus is an emerging virus and a select agent, requiring Biosafety Level 4-equivalent containment. It is endemic in West African countries, especially Sierra Leone, the Republic of Guinea, Nigeria, and Liberia, where the annual incidence of infection is between 300,000 and 500,000 cases, resulting in 5,000 deaths per year.", 8, 1, 1, 10));
            LI.infection.Add(new Infection("noim.png","Paracoccidioidomycosis", "Paracoccidioidomycosis (PCM) (also known as Brazilian blastomycosis South American blastomycosis Lutz - Splendore - de Almeida disease paracoccidioidal granuloma is a fungal infection caused by the fungus Paracoccidioides brasiliensis. Though sometimes called South American blastomycosis, paracoccidioidomycosis is caused by a different fungus than that which causes blastomycosis. ", 3, 1,30,15));
            LI.infection.Add(new Infection("Jc.jpg", "JC virus", "type of human polyomavirus (formerly known as papovavirus). It was identified by electron microscopy in 1965 by ZuRhein and Chou,and by Silverman and Rubinstein, and later isolated in culture and named using the two initials of a patient, John Cunningham, with progressive multifocal leukoencephalopathy (PML). The virus causes PML and other diseases only in cases of immunodeficiency, as in AIDS or during treatment with drugs intended to induce a state of immunosuppression (e.g. organ transplant patients).", 10, 1, 7,1));
            LI.infection.Add(new Infection("Clonor.jpg","Clonorchiasis", "caused by the Chinese liver fluke, Clonorchis sinensis, and two related species. Clonorchiasis is a known risk factor for the development of cholangiocarcinoma, a neoplasm of the biliary system. ", 10, 1, 5, 0));
            LG.genetic.Add(new Genetic("noim.png","Cockayne syndrome", "fatal autosomal recessive neurodegenerative disorder characterized by growth failure, impaired development of the nervous system, abnormal sensitivity to sunlight (photosensitivity), eye disorders and premature aging", 2, 10, 50, 80, 0, 40));
            LG.genetic.Add(new Genetic("noim.png","Neurofibromatosis", "group of three conditions in which tumors grow in the nervous system. The three types are neurofibromatosis type 1 (NF1), neurofibromatosis type 2 (NF2), and schwannomatosis. In NF1 symptoms include light brown spots on the skin, freckles in the armpit and groin, small bumps within nerves, and scoliosis", 4, 24, 30, 0, 15, 7));
            LG.genetic.Add(new Genetic("noim.png","Fabry disease", "affect many parts of the body including the kidneys, heart, and skin. Fabry disease is one of a group of conditions known as lysosomal storage diseases. ", 1,15,5, 6,20,12));
            LM.mental.Add(new Mental("insomnia3.jpg","Insomnia", "sleep disorder where people have trouble sleeping. They may have difficulty falling asleep, or staying asleep as long as desired. Insomnia is typically followed by daytime sleepiness, low energy, irritability, and a depressed mood.", 1, 10));
            //LM.mental.Add(new Mental("Insomnia", "sleep disorder where people have trouble sleeping. They may have difficulty falling asleep, or staying asleep as long as desired. Insomnia is typically followed by daytime sleepiness, low energy, irritability, and a depressed mood.", 1, 10));
            LM.mental.Add(new Mental("noim.png","Hypomania", "mood state characterized by persistent disinhibition and elevation (euphoria). It may involve irritation, but less severely than full mania. According to DSM-5 criteria, hypomania is distinct from mania in that there is no significant functional impairment; mania, by DSM-5 definition, does include significant functional impairment and may have psychotic features.", 1, 10));
            LM.mental.Add(new Mental("PA.jpg","Panic disorder", "anxiety disorder characterized by reoccurring unexpected panic attacks. Panic attacks are sudden periods of intense fear that may include palpitations, sweating, shaking, shortness of breath, numbness, or a feeling that something terrible is going to happen.The maximum degree of symptoms occurs within minutes.", 1, 16));
            LM.mental.Add(new Mental("Dysl.png","Dyslexia", "reading disorder, is characterized by trouble with reading despite normal intelligence. Different people are affected to varying degrees.[4] Problems may include difficulties in spelling words, reading quickly, writing words,  words in the head, pronouncing words when reading aloud and understanding what one reads.", 2, 4));
            */


            //DataContractJsonSerializer jsonFormat1 = new DataContractJsonSerializer(typeof(List<Infection>));
            //using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/IName.json", FileMode.Create))
            //{
            //    jsonFormat1.WriteObject(fs, LI.infection);
            //}
            //считывание
            DataContractJsonSerializer jsonSerializer1 = new DataContractJsonSerializer(typeof(List<Infection>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/IName.json", FileMode.Open))
            {
                LI.infection = (List<Infection>)jsonSerializer1.ReadObject(fs);
            }

            //// new Genetic Klinefelter = new Genetic()
            //DataContractJsonSerializer jsonFormat2 = new DataContractJsonSerializer(typeof(List<Mental>));
            //using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/MName.json", FileMode.Create))
            //{
            //    jsonFormat2.WriteObject(fs, LM.mental);
            //}
            //считывание
            DataContractJsonSerializer jsonSerializer2 = new DataContractJsonSerializer(typeof(List<Mental>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/MName.json", FileMode.Open))
            {
                LM.mental = (List<Mental>)jsonSerializer2.ReadObject(fs);
            }

            //DataContractJsonSerializer jsonFormat3 = new DataContractJsonSerializer(typeof(List<Genetic>));
            //using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/GName.json", FileMode.Create))
            //{
            //    jsonFormat3.WriteObject(fs, LG.genetic);
            //}
            //считывание
            DataContractJsonSerializer jsonSerializer3 = new DataContractJsonSerializer(typeof(List<Genetic>));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/GName.json", FileMode.Open))
            {
                LG.genetic = (List<Genetic>)jsonSerializer3.ReadObject(fs);
            }

            B4.Text = op.tclos;
            B1.Text = op.dis;

        }

        private void Button_Clicked4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Closest(op));
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GreetPage(LG, LI, LM, op));
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
            op = new Options("English");
            B4.Text = op.tclos;
            B1.Text = op.dis;
            DataContractJsonSerializer jsonFormat = new DataContractJsonSerializer(typeof(Options));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/op.json", FileMode.Create))
            {
                jsonFormat.WriteObject(fs, op);
            }
        }
        private void Button_Clicked3(object sender, EventArgs e)
        {
            op = new Options("Русский");
            B1.Text = op.dis;
            B4.Text = op.tclos;
            DataContractJsonSerializer jsonFormat = new DataContractJsonSerializer(typeof(Options));
            using (FileStream fs = new FileStream(FileSystem.AppDataDirectory + "/op.json", FileMode.Create))
            {
                jsonFormat.WriteObject(fs, op);
            }


        }

    }



}