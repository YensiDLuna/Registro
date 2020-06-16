using RegistroDeArticulos.BLL;
using RegistroDeArticulos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroDeArticulos.UI.Registro
{
	/// <summary>
	/// Interaction logic for rArticulos.xaml
	/// </summary>
	public partial class rArticulos : Window
	{
		private Articulo articulo = new Articulo();

		public rArticulos()
		{
			InitializeComponent();
			this.DataContext = articulo;

		}

		private void Cargar()
		{
			this.DataContext = null;
			this.DataContext = articulo;
		}

		private void Limpiar()
		{
			this.articulo = new Articulo();
			this.DataContext = articulo;

		}


		private bool Validar()
		{
			bool esValido = true;
			if (DescripcionTextBox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Transaccion fallida", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (ExistenciaTextBox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Transaccion fallida", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (CostoTextBox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Transaccion fallida", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (ValorInventarioTextBox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Transaccion fallida", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}



			return esValido;
		}

		private void BuscarButton_Click(object serder, RoutedEventArgs e)
		{
			Articulo encotrado = ArticuloBLL.Buscar(Utilidades.ToInt(ArticuloIdTextBox.Text));
			if (encotrado != null)
			{
				this.articulo = encotrado;
				Cargar();
				MessageBox.Show("Puntos encontrados!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				Limpiar();
				MessageBox.Show("No existe en la base de datos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void NuevoButton_Click(object serder, RoutedEventArgs e)
		{
			Limpiar();
		}
		private void GuardarButton_Click(object serder, RoutedEventArgs e)
		{

			if (!Validar())
			{
				return;
			}
			var paso = ArticuloBLL.Guardar(articulo);
			if (paso)
			{
				Limpiar();
				MessageBox.Show("Exito Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				MessageBox.Show("Exito Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void CostotextChanged(object sender, TextChangedEventArgs args)
		{
			decimal costo = Utilidades.ToDecimal( CostoTextBox.Text);
			int exitencia = Utilidades.ToInt(ExistenciaTextBox.Text);

			costo *= exitencia;

			ValorInventarioTextBox.Text = costo.ToString();

		}

		private void ExistenciatextChanged(object sender, TextChangedEventArgs args)
		{
			decimal costo = Utilidades.ToDecimal(CostoTextBox.Text);
			int existencia = Utilidades.ToInt(ExistenciaTextBox.Text);

			costo *= existencia;

			ValorInventarioTextBox.Text = costo.ToString();

		}



		private void EliminarButton_Click(object sender, RoutedEventArgs e)

		{

			if (ArticuloBLL.Eliminar(Utilidades.ToInt(ArticuloIdTextBox.Text)))

			{

				Limpiar();

				MessageBox.Show("Eliminado", "EXITO");

			}

			else

			{

				MessageBox.Show("No se pudo eliminar", "Error");

			}

		}
	}
}
