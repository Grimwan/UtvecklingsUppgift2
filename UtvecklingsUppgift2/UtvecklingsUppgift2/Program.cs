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
            DataHanteringsLager lager = new DataHanteringsLager();

            foreach (var tävling in lager.GetAllTävlingar())
            {
                Console.WriteLine("Tävlings namn: " + tävling.Namn);
                Console.WriteLine("Deltagarna i tävlingen");

                foreach (var deltagare in tävling.AllaDeltagarna)
                {
                    Console.WriteLine(deltagare.Namn);
                }
                Console.WriteLine("_______________________________");
            }
            Console.ReadKey();
        }
    }
}
