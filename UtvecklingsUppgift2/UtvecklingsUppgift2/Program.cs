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
        public class Deltagare
        {
            public int ID { get; set; }
            public string Namn { get; set; }
            public int TävlingsId { get; set; }
            public Tävling Tävling { get; set; }
        }
        public class Tävling
        {
            public int ID { get; set; }
            public string Namn { get; set; }
            public List<Deltagare> Alladeltagarna { get; set; }
        }

        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("data source=.\\SQLEXPRESS;database=Competitions; integrated security=SSPI");
            SqlCommand cmdTävlingar = new SqlCommand("SELECT * from Tävling", con);
            con.Open();



            SqlDataAdapter daTävling = new SqlDataAdapter(cmdTävlingar);
            var TävlingTable = new DataTable();

            daTävling.Fill(TävlingTable);

            List<Tävling> Competitons = new List<Tävling>();
            foreach (DataRow row in TävlingTable.Rows)
            {
                Tävling tävling = new Tävling();
                tävling.ID = Int32.Parse(row["ID"].ToString());
                tävling.Namn = row["Namn"].ToString();

                List<Deltagare> Participants = new List<Deltagare>();

                SqlCommand cmdDeltagare = new SqlCommand("SELECT Namn from Deltagares WHERE TävlingsId = " + tävling.ID, con);
                SqlDataAdapter daDeltagare = new SqlDataAdapter(cmdDeltagare);
                var DeltagreTable = new DataTable();
                daDeltagare.Fill(DeltagreTable);
                foreach (DataRow InternalRow in DeltagreTable.Rows)
                {
                    Deltagare deltagare = new Deltagare();
                    deltagare.Namn = InternalRow["Namn"].ToString();
                    Participants.Add(deltagare);
                }
                tävling.Alladeltagarna = Participants;

                Competitons.Add(tävling);
            }
            con.Close();
            foreach (var tävling in Competitons)
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
