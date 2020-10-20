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
    public partial class rMoras : Window
    {
       Moras moras = new Moras();

        public rMoras ()
        {
            InitializeComponent();
        
           this.DataContext = moras;
           MorasIDTextBox.Text = "0";
        
        }
        private void Limpiar()
        {
            MorasIDTextBox.Text = "0";
            FechaDatePickerTextBox.Text = Convert.ToString(DateTime.Now);

          // TotalTextBox_TextChanged.ItemsSouce = new List<MorasDetalle>();
            Actualizar();
        }

           private void Actualizar() 
        {
            this.DataContext = null;
            this.DataContext = moras;
        }

        private bool ExisteDB(){
            moras= MorasBLL.Buscar(Convert.ToInt32(MorasIDTextBox.Text));
            return (moras != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (string.IsNullOrWhiteSpace(MorasIDTextBox.Text) || MorasIDTextBox.Text == "0")
                paso = MorasBLL.Guardar(moras);
            else 
            {
                if(!ExisteDB())
                {
                    MessageBox.Show("No se puede modificar porque no existe");
                    return;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar!");
                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(MorasIDTextBox.Text);

            Limpiar();

            if(MorasBLL.Eliminar(id))
                MessageBox.Show("Se elimino Correctamente");
            else
                MessageBox.Show(MorasIDTextBox.Text,"No se pudo eliminar!");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Moras anterior = MorasBLL.Buscar(Convert.ToInt32(MorasIDTextBox));

            if(anterior != null)
            {
                moras = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e){
            moras.MorasDetalle.Add(new MorasDetalle(Convert.ToInt32(MorasIDTextBox.Text), Convert.ToInt32(PrestamoIDTextBox.Text),
            Convert.ToInt32(ValorTextBox.Text)));

            MorasIDTextBox.Clear();
            PrestamoIDTextBox.Clear();
            ValorTextBox.Clear();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            moras.MorasDetalle.RemoveAt(DetalleDataGrid.FrozenColumnCount);
            Actualizar();
        }

    }
    }