//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Panderia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class precio_venta
    {
        public precio_venta()
        {
            this.detalle_produccion = new HashSet<detalle_produccion>();
        }
    
        public int Id { get; set; }
        public System.DateTime fecha { get; set; }
        public int valor { get; set; }
    
        public virtual ICollection<detalle_produccion> detalle_produccion { get; set; }
    }
}
