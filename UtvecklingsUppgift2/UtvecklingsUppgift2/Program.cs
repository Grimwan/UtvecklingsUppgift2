using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace UtvecklingsUppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataHanteringsLager Lager = new DataHanteringsLager();         
            foreach (var tävling in Lager.GetAllTävlingar())
            {
                Console.WriteLine("Tävlings Namn: " + tävling.Namn);
                Console.WriteLine("Deltagarna i tävlingen");

                foreach (var deltagare in tävling.Alladeltagarna)
                {
                    Console.WriteLine(deltagare.Namn);
                }
                Console.WriteLine("_______________________________");
            }
            Console.ReadKey();
        }
    }
}
