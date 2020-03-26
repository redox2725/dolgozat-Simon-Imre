using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doga
{
    class versenyzo
    {
        public string nev { get; private set; }
        public string kategoria { get; private set; }
        public string egyesulet { get; private set; }
        public byte[] pontok { get; set; }

        public int osszpont;


        public versenyzo(string sor)
        {
            string[] s = sor.Split(';');
            nev = s[0]; 
            kategoria = s[1]; 
            egyesulet = s[2]; 
            pontok = new byte[8]; for (int i = 0; i < pontok.Length; i++)
            {
                pontok[i] = byte.Parse(s[i + 3]);
            }
        }
        public int osszpontszam {
            get 
            { 
                int osszpont = 0; Array.Sort(pontok);
                for (int i = 2; i < pontok.Length; i++) { osszpont += pontok[i];
                } 
                if (pontok[0] != 0) osszpont += 10; if (pontok[1] != 0) osszpont += 10; return osszpont; 
            } 
        
        }



        }


    
    }


