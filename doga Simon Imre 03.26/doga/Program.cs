using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace doga
{
    class Program
    {
      

        static void Main(string[] args)
        {
            double versenyzokszama = 0; 
            List<versenyzo> vers = new List<versenyzo>();
            foreach (var i in File.ReadAllLines(@"..\..\res\fob2016.txt"))
            {
                vers.Add(new versenyzo(i));
            }




            versenyzokszama = vers.Count();
            Console.WriteLine("3. feladat: \nVersenyzők száma: {0}", versenyzokszama);



            Console.WriteLine("\nFeladat 4");
            {
                int no = vers.FindAll(x => x.kategoria.Contains("Noi")).Count;
                double noiarany = (Convert.ToDouble(no) / vers.Count) * 100;
                Console.WriteLine($"A női versenyzők aránya: {noiarany.ToString("#.##")}%");
            }




            StreamWriter sw = new StreamWriter("osszpontFF.txt", false);
            List<versenyzo> ferfiak = vers.FindAll(x => x.kategoria.Contains("Felnott ferfi"));
            foreach (versenyzo f in ferfiak)
            {
                sw.WriteLine(f.nev + ";" + f.osszpont);
            }
            sw.Close();


            versenyzo Noilegjobb = vers.FindAll(x => x.kategoria.Contains("Noi")).OrderByDescending(x => x.osszpont).First();
            Console.WriteLine($"6. feladat:A bajok női versenyzpő \nnev: {Noilegjobb.nev} \negyesület: {Noilegjobb.egyesulet} \nösszpont: {Noilegjobb.pontok}");



            var list = vers.GroupBy(x => x.kategoria).Select(x => x.ToList()).ToList();



            Console.ReadLine();

        }

    }
}
