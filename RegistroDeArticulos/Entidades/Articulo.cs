using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroDeArticulos.Entidades
{
  public class Articulo
	{
        [Key]
        public int articuloId { get; set; }
        public string descripcion { get; set; }
        public int existencia { get; set; }
        public decimal costo { get; set; }
        public decimal valorInventario { get; set; }

        public Articulo(int articuloId, string descripcion, int existencia, decimal costo, decimal valorInventario)
        {
            this.articuloId = articuloId;
            this.descripcion = descripcion;
            this.existencia = existencia;
            this.costo = costo;
            this.valorInventario = valorInventario;
        }

        public Articulo()
        {
            articuloId = 0;
            descripcion = string.Empty;
            existencia = 0;
            costo = 0;
            valorInventario = 0;
        }


    }
}
