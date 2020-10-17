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
    public partial class rPersonas : Window
    {
        private Personas personas = new Personas();

        public rPersonas ()
        {
            InitializeComponent();
        
            this.DataContext = personas;
        
        }
       
        private void Limpiar(){
            this.personas= new Personas();
            this.DataContext = personas;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e){
            var encontrado =PersonasBLL.Buscar(Convert.ToInt32(PersonaIDTextBox.Text));
            if(encontrado!=null)
                personas = encontrado;
            else
            {
                Limpiar();
            }
            this.DataContext = personas;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e){
            var paso = PersonasBLL.Guardar(personas);
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

            if(PersonasBLL.Eliminar(Convert.ToInt32(PersonaIDTextBox.Text))){
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
