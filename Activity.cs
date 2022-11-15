using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDB
{
    internal class Activity
    {
        public int Aktiv_id { get; set;}
        public string? Type { get; set; }
        public int Price { get; set; }
        public int Hotel_No { get; set; }

        public override string ToString()
        {
            return $"ID : {Aktiv_id} Aktivitet : {Type} Pris : {Price} Hotel Nr: {Hotel_No} ";
        }
    }
}
