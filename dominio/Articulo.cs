using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        
        public int id { get; set; }
        public string codigo { get; set; }
        [DisplayName ("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [DisplayName("Marca")]
        public Marca marca { get; set; }
        [DisplayName("Categoria")]
        public Categoria categoria { get; set; }
        [DisplayName("Url Imagen")]
        public Imagen imagen { get; set; }
        [DisplayName("Precio")]
        public decimal precio { get; set; }

        public List<string> imagenes { get; set; }
    }
}
