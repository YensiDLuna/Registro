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

namespace RegistroDeArticulos.UI.Consulta
{
	/// <summary>
	/// Interaction logic for cArticulo.xaml
	/// </summary>
	public partial class cArticulo : Window
	{
		public cArticulo()
		{
			InitializeComponent();
		}

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)

        {

            var listado = new List<Articulo>();

            if (CriterioTextBox.Text.Trim().Length > 0)

            {

                switch (FiltroComboBox.SelectedIndex)

                {

                    case 0: 

                        listado = ArticuloBLL.GetList(e => e.articuloId == Utilidades.ToInt(CriterioTextBox.Text));

                        break;



                    case 1:                       

                        listado = ArticuloBLL.GetList(e => e.descripcion.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));

                        break;

                }







            }

            else

            {

                listado = ArticuloBLL.GetList(c => true);

            }



            DatosDataGrid.ItemsSource = null;

            DatosDataGrid.ItemsSource = listado;

        }
    }
}
