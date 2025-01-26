using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SPJMauiApp.Models
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Make { get; set; } // Marca del coche
        public string Model { get; set; } // Modelo del coche
        public int Year { get; set; } // Año de fabricación
        public string Class { get; set; } // Clase del coche
    }
}
