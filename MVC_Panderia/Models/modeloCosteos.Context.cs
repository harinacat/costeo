﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pan_dbEntities1 : DbContext
    {
        public pan_dbEntities1()
            : base("name=pan_dbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<articulo> articuloes { get; set; }
        public DbSet<cabecera_produccion> cabecera_produccion { get; set; }
        public DbSet<cabecera_receta> cabecera_receta { get; set; }
        public DbSet<costo> costos { get; set; }
        public DbSet<detalle_produccion> detalle_produccion { get; set; }
        public DbSet<detalle_receta> detalle_receta { get; set; }
        public DbSet<familia> familias { get; set; }
        public DbSet<linea> lineas { get; set; }
        public DbSet<unidad_medida> unidad_medida { get; set; }
        public DbSet<precio_venta> precio_venta { get; set; }
        public DbSet<usuario> usuarios { get; set; }
    }
}
