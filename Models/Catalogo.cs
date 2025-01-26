using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPJMauiApp.Models
{
    public class Catalogo
    {
        
            public int catalogoId { get; set; }
            public string? marca { get; set; }
            public string? modelo { get; set; }
            public bool usado { get; set; }
            public decimal precio { get; set; }
            public decimal iva { get; set; }
            public string? ImagePath { get; set; }

            public bool IsImageVisible { get; set; }

    }


}
