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
using RegistroDetalle.UI.Registro;
using RegistroDetalle.UI.Consultas;

namespace RegistroDetalle
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

          private void RegistrarPersonas_Click(object sender, RoutedEventArgs e)
        {
            rPersonas ventana = new rPersonas();
            ventana.Show();
        }
          private void  RegistrarPrestamo_Click(object sender, RoutedEventArgs e)
        {
            rPrestamo ventana = new rPrestamo();
            ventana.Show();
        }

       
          private void RegistrarMoras_Click(object sender, RoutedEventArgs e)
        {
            rMoras ventana = new rMoras();
            ventana.Show();
        }

         public void ConsultarPrestamo_Click(object render, RoutedEventArgs e)
        {
            cPrestamo cPrestam = new cPrestamo();
            cPrestam.Show();
        }
    }

    }
