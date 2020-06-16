using Microsoft.EntityFrameworkCore;
using RegistroDeArticulos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDeArticulos.DAL
{
	class Contexto : DbContext
    {
		
        public DbSet<Articulo> Articulo { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source =DATA\ArticuloComtrol.db");
        }


    }
}
