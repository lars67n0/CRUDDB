// See https://aka.ms/new-console-template for more information
using CRUDDB;

namespace CRUDDB
{
    class Program
    {
        static void Main(string[] args)
        {
            DBClient dbc = new DBClient();
            dbc.Start();
        }
    }

}

