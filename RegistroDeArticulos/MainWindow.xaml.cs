using RegistroDeArticulos.UI.Consulta;
using RegistroDeArticulos.UI.Registro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroDeArticulos
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		public void rArticuloMenuItem_Click(object sender, RoutedEventArgs e)
		{
			rArticulos ra = new rArticulos();
			ra.Show();

		}
		
		public void cArticuloMenuItem_Click(object sender, RoutedEventArgs e)
		{
			cArticulo ca = new cArticulo();
			ca.Show();

		}

	}
}
