using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MedLib
{
    [Serializable]
    public class Infection
    {

        public Infection()
        {
            Name = "qwe";
            Development = "qwe";
            IncubationPeriod = 0;
            Prevalence = 0;
            Age = 0;
            Severity = 0;
        }

        public Infection(string name, string development, int incubation, int prevalence,
            int age, int severity)
        {
            this.WayToPhoto = null;
            this.Name = name;
            this.Development = development;
            this.IncubationPeriod = incubation;
            this.Prevalence = prevalence;
            this.Age = age;
            this.Severity = severity;
        }

        public Infection(string way, string name, string development, int incubation, int prevalence,
            int age, int severity)
        {
            this.Name = name;
            this.Development = development;
            this.IncubationPeriod = incubation;
            this.Prevalence = prevalence;
            this.Age = age;
            this.Severity = severity;
            this.WayToPhoto = way;
        }
        private string wtp;
        public string Name { get; set; }
        public string Development { get; set; }
        public int IncubationPeriod { get; set; }
        public int Prevalence { get; set; }
        public int Age { get; set; }
        public int Severity { get; set; }
        public string WayToPhoto { get => wtp; set => wtp = value; }
    }
    [Serializable]
    public class Genetic
    {
        /*  Genetic()
          {
              Name = null;
              Development = null;
              PropOfInheritanceMom = 0;
              PropOfInheritanceDad = 0;
              PropOfInheritance = 0;
              Prevalence = 0;
              Age = 0;
              Severity = 0;
          }
          */

        public Genetic(string name, string development, int prevalence,
            int age, int severity, int mom, int dad, int inheritance)
        {
            this.WayToPhoto = null;
            this.Name = name;
            this.Development = development;

            this.Prevalence = prevalence;
            this.Age = age;
            this.Severity = severity;
            this.PropOfInheritanceMom = mom;
            this.PropOfInheritanceDad = dad;
            this.PropOfInheritance = inheritance;
        }
        public Genetic(string way, string name, string development, int prevalence,
    int age, int severity, int mom, int dad, int inheritance)
        {
            this.Name = name;
            this.Development = development;

            this.Prevalence = prevalence;
            this.Age = age;
            this.Severity = severity;
            this.PropOfInheritanceMom = mom;
            this.PropOfInheritanceDad = dad;
            this.PropOfInheritance = inheritance;
            this.WayToPhoto = way;
        }

        public Genetic()
        {
            this.Name = "some";
            this.Development = "some";

            this.Prevalence = 0;
            this.Age = 0;
            this.Severity = 0;
            this.PropOfInheritanceMom = 0;
            this.PropOfInheritanceDad = 0;
            this.PropOfInheritance = 0;
        }
        private string wtp;
        public string WayToPhoto { get => wtp; set => wtp = value; }
        public string Name { get; set; }
        public string Development { get; set; }
        public int Prevalence { get; set; }
        public int Age { get; set; }
        public int Severity { get; set; }
        public int PropOfInheritanceMom { get; set; }
        public int PropOfInheritanceDad { get; set; }
        public int PropOfInheritance { get; set; }
    }
    [Serializable]
    public class Mental
    {
        private string _name;

        public Mental(string way, string name, string development, int prevalence,
        int age)
        {
            this.Name = name;
            this.Development = development;
            this.Prevalence = prevalence;
            this.Age = age;
            this.WayToPhoto = way;
        }
        public Mental(string name, string development, int prevalence,
  int age)
        {
            this.WayToPhoto = null;
            this.Name = name;
            this.Development = development;
            this.Prevalence = prevalence;
            this.Age = age;
        }

        public Mental()
        {
            this.Name = "qwe";
            this.Development = "qwe";
            this.Prevalence = 0;
            this.Age = 0;
            
        }
        private string wtp;
        public string Name { get => _name; set => _name = value; }
        public string Development { get; set; }
        public int Prevalence { get; set; }
        public int Age { get; set; }
        public string WayToPhoto { get => wtp; set => wtp = value; }
    }

    public class LibraryInfection : IEnumerable
    {
        //        private Infection[] infection;
        public List<Infection> infection = new List<Infection>();
        public LibraryInfection()
        { }
        
        

        public Infection FindInf(string name)
        {
            Infection buffer = new Infection();
            foreach (Infection element in infection)
            {
                if (element.Name == name)
                {
                    buffer = element;
                    //buffer.Name = element.Name;
                    //buffer.Severity = element.Severity;
                    break;
                }
            }
            return buffer;
        }


        public Infection this[int index]
        {
            get
            {
                return infection[index];
            }
            set
            {
                infection[index] = value;
            }
        }

        // возвращаем перечислитель
        IEnumerator IEnumerable.GetEnumerator()
        {
            return infection.GetEnumerator();
        }
    }


    public class LibraryGenetic : IEnumerable
    {
        //private Genetic[] genetic;
        public List<Genetic> genetic = new List<Genetic>();

        public LibraryGenetic()
        {}


        public Genetic FindGen(string name)
        {
            Genetic buffer = new Genetic();
            foreach (Genetic element in genetic)
            {
                if (element.Name == name)
                {
                    buffer = element;
                    break;
                }
            }
            return buffer;
        }

        public Genetic this[int index]
        {
            get
            {
                return genetic[index];
            }
            set
            {
                genetic[index] = value;
            }
        }

        // возвращаем перечислитель
        IEnumerator IEnumerable.GetEnumerator()
        {
            return genetic.GetEnumerator();
        }
    }

    public class LibraryMental : IEnumerable
    {
        // private Mental[] mental;
        public List<Mental> mental = new List<Mental>();

        public LibraryMental()
        {
            
        }

        public Mental FindInf(string name)
        {
            Mental buffer = new Mental();
            foreach (Mental element in mental)
            {
                if (element.Name == name)
                {
                    buffer = element;
                    break;
                }
            }
            return buffer;
        }

  

        public Mental this[int index]
        {
            get
            {
                return mental[index];
            }
            set
            {
                mental[index] = value;
            }
        }

        // возвращаем перечислитель
        IEnumerator IEnumerable.GetEnumerator()
        {
            return mental.GetEnumerator();
        }
    }


    [Serializable]
    public class Hospital
    {
        public string Name;
        public Location Loc;

        public Hospital(string name, Location loc)
        {
            this.Name = name;
            this.Loc = loc;
        }
    }

    [Serializable]
    public class Options
    {
        public string dis;
        public string gen;
        public string ment;
        public string inf;
        public string leng;
        public string find;
        public string add;
        public string view;
        public string save;
        public string settings;
        public string ok;
        public string work;
        public string l1;
       // public string labch;
        public string s1;
        public string search;
        public string chlab;

        public string name;
        public string development;
        public string prevalence;
        public string age;
        public string severity;
        public string incub;
        public string iname;
        public string uloc;
        public string closest;
        public string gloc;
        public string tclos;
        public string idevelopment;
        public string iprevalence;
        public string iage;
        public string iseverity;
        public string iincub;
        public string mom;
        public string dad;
        public string inh;
        public string  im;
        public string wtf;
        public string iwtf;

        public string addD;
        public string GD;
        public string tinh;

        // string
        public Options(string ch)
        {
            if(ch == "English")
            {
                dis = "Diseases";
                gen = "Genetic";
                ment = "Mental";
                inf = "Infection";
                leng = "English";
                find = "Find";
                add = "Add";
                view = "View";
                save = "Save";
                settings = "Setting";
                ok = "Ok";
                work = "Work with disease";
                l1 = "Chose type of disease";
                im = "Image";
                wtf = "Way to image";
                iwtf = "name of image";
                s1 = "Pick your action";
                search ="Search";
                name = "Name";
                development = "Development";
                prevalence = "Prevalence";
                age = "Age";
                severity = "Severity";
                incub = "Incubation period";
                tinh = "Inheritance";

                uloc = "Your location is: ";
                closest = "Closest hospital is: ";
                gloc = "Get location: ";
                tclos = "To closest Hospital!";

                iname = "input name";
                idevelopment = "descibe development";
                iprevalence = "descibe prevalence";
                iage = "enter age";
                iseverity = "enter severity";
                iincub = "enter incubation period";
                mom = "Propobility to inheretance from mom";
                dad = "Propobility to inheretance from dad";
                inh = "Propobility to inheretance";
                addD = "Add disease";
                GD = "General data";
               
            }
            else
            {
                dis = "Болезни";
                gen = "Генетические";
                ment = "Психические";
                inf = "Инфекция";
                leng = "Русский";
                find = "Поиск";
                add = "Добавление";
                view = "Просмотр";
                save = "Сохранить";
                settings = "Настройки";
                ok = "Закрыть";
                work = "Работа с болезнями";
                
                l1 = "Выбор болезни";
                s1 = "Выбор действия";
                search = "Поиск";

                name = "Название";
                development = "Протекание";
                prevalence = "Распространенность";
                age = "Возраст";
                severity = "Смертность";
                incub = "Инкубационный период";

                uloc = "Ваше местоположение: ";
                closest = "Ближайшая больница: ";
                gloc = "Узнать местонохождение";
                tclos = "В ближайшую больницу!";


                iname = "введите название";
                idevelopment = "опишите протекание";
                iprevalence = "введите распространенность";
                iage = "введите минимальный возраст";
                iseverity = "введите смертность на миллион";
                iincub = "укажите инкубационный период";
                mom = "вероятность наследования от матери";
                dad = "вероятность наследования от отца";
                inh = "вероятность наследования";
                im = "Изображение";
                wtf = "Путь к изображению";
                iwtf = "введите название";
                tinh = "Наследственность";

                addD = "Добавление болезни";
                GD = "Общая информация";
                
            }
        }

    }

}
