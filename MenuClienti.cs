using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class MenuClienti : Menu
    {
    
        public MenuClienti(List<Cliente> clienti, List<Prestito> prestiti, Banca banca) : base("Menu Clienti", clienti, prestiti, banca)
        {
         
        }


    }
}
