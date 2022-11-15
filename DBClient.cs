using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace CRUDDB
{
    internal class DBClient
    {
        
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rikar\source\repos\CRUDDB\Database1.mdf;Integrated Security=True";

        private int GetAktiv(SqlConnection connection)
        {
            Console.WriteLine("kalder på GetAktiv");

            
            string queryStringAktiv = "SELECT  MAX(Aktiv_id)  FROM Aktivitet";
            Console.WriteLine($"SQL applied: {queryStringAktiv}");

           
            SqlCommand command = new SqlCommand(queryStringAktiv, connection);
            SqlDataReader reader = command.ExecuteReader();

           
            int Aktiv = 0;

           
            if (reader.Read())
            {
                
                Aktiv = reader.GetInt32(0); 
            }

         
            reader.Close();

            Console.WriteLine($"Max Activity#: {Aktiv}");
            Console.WriteLine();

            /
            return Aktiv;
        }



        private Activity? GetAktivitet(SqlConnection connection, int Aktiv_id)
        {
            Console.WriteLine("Calling -> GetHotel");

            
            string queryStringOneAktiv = $"SELECT * FROM Aktivitet WHERE Aktiv_id = {Aktiv_id}";
            Console.WriteLine($"SQL applied: {queryStringOneAktiv}");

           
            SqlCommand command = new SqlCommand(queryStringOneAktiv, connection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine($"Finding hotel#: {Aktiv_id}");

             
            if (!reader.HasRows)
            {
                
                Console.WriteLine("No Aktiv ID in database");
                reader.Close();

               
                return null;
            }

            
            Activity? Aktiv = null;
            if (reader.Read())
            {
                Aktiv = new Activity
                {
                    
                    Aktiv_id = reader.GetInt32(0), 
                    Hotel_No = reader.GetInt32(1),    
                    Type = reader.GetString(2),
                    Price = reader.GetInt32(3)
                };

                Console.WriteLine(Aktiv);
            }

          
            reader.Close();
            Console.WriteLine();

            
            return Aktiv;
        }



        private int DeleteAktivitet(SqlConnection connection, int GetAktiv)
        {
            Console.WriteLine("Calling -> DeleteHotel");

           
            string deleteCommandString = $"DELETE FROM DemoHotel  WHERE Hotel_No = {GetAktiv}";
            Console.WriteLine($"SQL applied: {deleteCommandString}");

            
            SqlCommand command = new SqlCommand(deleteCommandString, connection);
            Console.WriteLine($"Deleting hotel #{GetAktiv}");
            int numberOfRowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"Number of rows affected: {numberOfRowsAffected}");
            Console.WriteLine();

            
            return numberOfRowsAffected;
        }

        private List<Activity>? ListAllActivities(SqlConnection connection)
        {
            Console.WriteLine("Calling -> ListAllHotels");

            
            string queryStringAllAktiv = "SELECT * FROM Aktivitet";
            Console.WriteLine($"SQL applied: {queryStringAllAktiv}");

          
            SqlCommand command = new SqlCommand(queryStringAllAktiv, connection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Listing all Aktiviteter:");

          
            if (!reader.HasRows)
            {
               
                Console.WriteLine("No Aktiviteter in database");
                reader.Close();

                
                return null;
            }

           
            List<Activity> Aktivs = new List<Activity>();
            while (reader.Read())
            {
                
                Activity nextAktiv = new Activity()
                {
                    Aktiv_id = reader.GetInt32(0), 
                    Hotel_No = reader.GetInt32(1),    
                    Type = reader.GetString(2),
                    Price = reader.GetInt32(3)
                };

                Aktivs.Add(nextAktiv);

                Console.WriteLine(nextAktiv);
            }

            reader.Close();
            Console.WriteLine();

            return Aktivs;
        }

        private int UpdateHotel(SqlConnection connection, Activity Aktivitet)
        {
            Console.WriteLine("Calling -> UpdateHotel");

            string updateCommandString = $"UPDATE DemoHotel SET Aktiv_id='{Aktivitet.Aktiv_id}', Type='{Aktivitet.Type}', pris='{Aktivitet.Price}' WHERE HOTEL = {Aktivitet.Hotel_No}";
            Console.WriteLine($"SQL applied: {updateCommandString}");

            SqlCommand command = new SqlCommand(updateCommandString, connection);
            Console.WriteLine($"Updating hotel #{Aktivitet.Hotel_No}");
            int numberOfRowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"Number of rows affected: {numberOfRowsAffected}");
            Console.WriteLine();

          
            return numberOfRowsAffected;
        }

        private int InsertAktiv(SqlConnection connection, Activity Aktivitet)
        {
            Console.WriteLine("Calling -> Aktivitet");

           
            string insertCommandString = $"INSERT INTO Aktivitet VALUES({Aktivitet.Aktiv_id}, '{Aktivitet.Type}', '{Aktivitet.Price}', '{Aktivitet.Hotel_No}')";
            Console.WriteLine($"SQL applied: {insertCommandString}");

           
            SqlCommand command = new SqlCommand(insertCommandString, connection);

            Console.WriteLine($"Creating Aktivitet #{Aktivitet.Aktiv_id}");
            int numberOfRowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"Number of rows affected: {numberOfRowsAffected}");
            Console.WriteLine();

           
            return numberOfRowsAffected;
        }

        

      

        public void Start()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();

               
                ListAllActivities(connection);

               
                Activity newActivity = new Activity()
                { Aktiv_id = GetAktiv(connection) + 1, Hotel_No = 1, Type = "Svømmehal", Price = 100, };

                //InsertAktiv(connection, newActivity);
                //Console.WriteLine("Updated List : ");

                ////List All Activities
                //ListAllActivities(connection);
                
                //Activity aktivitet = GetAktivitet(connection, aktivitet.Aktiv_id);

                //UpdateHotel(connection, aktivitet);

                //Activity activity = GetAktivitet(connection, activity.Aktiv_id);

                //DeleteAktivitet(connection, AktivDelete.Aktiv_id);

        
                ListAllActivities(connection);

                ListAllActivities(connection);
            }
        }


    }
}
