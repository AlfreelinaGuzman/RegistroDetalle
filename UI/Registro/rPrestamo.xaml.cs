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
using RegistroDetalle.Entidades;
using RegistroDetalle.BLL;

namespace RegistroDetalle.UI.Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class rPrestamo : Window
    {
        private Prestamo prestamo = new Prestamo();

        public rPrestamo ()
        {
            InitializeComponent();
        
            this.DataContext = prestamo;
        
        }
       
        private void Limpiar(){
            this.prestamo= new Prestamo();
            this.DataContext = prestamo;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e){
            var encontrado =PrestamoBLL.Buscar(Convert.ToInt32(PrestamoIDTextBox.Text));
            if(encontrado!=null)
                prestamo = encontrado;
            else
            {
                Limpiar();
            }
            this.DataContext = prestamo;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e){
            var paso = PrestamoBLL.Guardar(prestamo);
            if (paso){
                MessageBox.Show("Guardo Correctamente!");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Lo sentimos no se pudo guardar!");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e){

            if(PersonasBLL.Eliminar(Convert.ToInt32(PrestamoIDTextBox.Text))){
                MessageBox.Show("Se elimino correctamente!");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Lo sentimos no se pudo Eliminar");
            }
        }


    }
}