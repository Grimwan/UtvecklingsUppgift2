using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace UtvecklingsUppgift2
{
    class DataHanteringsLager
    {
        private string connectionInformation = "data source=.\\SQLEXPRESS;database=Competitions; integrated security=SSPI";
        public List<Tävling> GetAllTävlingar()
        {
            using (SqlConnection connection = new SqlConnection(connectionInformation))
            {
                //Gather all data From the Tävling table
                SqlCommand cmdTävlingar = new SqlCommand("SELECT * from Tävling", connection);
                connection.Open();

                SqlDataAdapter daTävling = new SqlDataAdapter(cmdTävlingar);
                var tävlingsTable = new DataTable();

                //Saves all the data into a DataTable.
                daTävling.Fill(tävlingsTable);

                List<Tävling> competitons = new List<Tävling>();

                //Iterates each row in the tävlingsTable and copys all the relevant information to a newly created Tävlings object and then adds that object to the list. 
                foreach (DataRow row in tävlingsTable.Rows)
                {
                    Tävling tävling = new Tävling();
                    tävling.ID = Int32.Parse(row["ID"].ToString());
                    tävling.Namn = row["Namn"].ToString();

                    //A new list is created for all the participants. It will be filled with all the participants that competed in that Tävling.
                    List<Deltagare> Participants = new List<Deltagare>();
                    SqlCommand cmdDeltagare = new SqlCommand("SELECT * from Deltagare WHERE TävlingsID = " + tävling.ID, connection);
                    SqlDataAdapter daDeltagare = new SqlDataAdapter(cmdDeltagare);
                    var deltagreTable = new DataTable();
                    daDeltagare.Fill(deltagreTable);
                    //Iterate all the particpants that was competing in the specific competition. 
                    foreach (DataRow InternalRow in deltagreTable.Rows)
                    {
                        Deltagare deltagare = new Deltagare();
                        deltagare.Namn = InternalRow["Namn"].ToString();
                        deltagare.Tävling = tävling;
                        deltagare.TävlingsID = Int32.Parse(InternalRow["TävlingsID"].ToString());
                        deltagare.ID = Int32.Parse(InternalRow["ID"].ToString());
                        Participants.Add(deltagare);
                    }
                    tävling.AllaDeltagarna = Participants;

                    competitons.Add(tävling);
                }
                //Returns a list with Tävlingar and what competitors that participated in each Tävling.
                return competitons;
            }
        }
        public Tävling GetTävling(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionInformation))
            {
                //Gather all data From the Tävling table
                SqlCommand cmdTävlingar = new SqlCommand("SELECT * from Tävling WHERE ID = "+ID, connection);
                connection.Open();

                SqlDataAdapter daTävling = new SqlDataAdapter(cmdTävlingar);
                var tävlingsTable = new DataTable();

                //Save all the data into a  DataTable.
                daTävling.Fill(tävlingsTable);

                Tävling tävling = new Tävling();

                DataRow row = tävlingsTable.Rows[0];
                
                tävling.ID = Int32.Parse(row["ID"].ToString());
                tävling.Namn = row["Namn"].ToString();

                //A new list is created for all the participants. It will be filled with all the participants that competed in that Tävling.
                List<Deltagare> Participants = new List<Deltagare>();
                SqlCommand cmdDeltagare = new SqlCommand("SELECT * from Deltagare WHERE TävlingsID = " + tävling.ID, connection);
                SqlDataAdapter daDeltagare = new SqlDataAdapter(cmdDeltagare);
                var deltagreTable = new DataTable();
                daDeltagare.Fill(deltagreTable);
                foreach (DataRow InternalRow in deltagreTable.Rows)
                {
                    Deltagare deltagare = new Deltagare();
                    deltagare.Namn = InternalRow["Namn"].ToString();
                    deltagare.Tävling = tävling;
                    deltagare.TävlingsID = Int32.Parse(InternalRow["TävlingsID"].ToString());
                    deltagare.ID = Int32.Parse(InternalRow["ID"].ToString());
                    Participants.Add(deltagare);
                }
                tävling.AllaDeltagarna = Participants;
               
                //returns Tävling and what competitors that participated in that Tävling.
                return tävling;
            }
        }
    }
}
