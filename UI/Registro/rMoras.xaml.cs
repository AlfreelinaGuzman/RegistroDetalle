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
using RegistroDetalle.DAL;

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
            PrestamoIDComboBox.ItemsSource = PrestamoBLL.GetList();
            PrestamoIDComboBox.SelectedValuePath = "PrestamoID";
            PrestamoIDComboBox.DisplayMemberPath = "PrestamoID";
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

            if (moras.MoraId == 0)
            {
                paso = MorasBLL.Guardar(moras);
            }
            else
            {
                if (Existe())
                {
                    paso = MorasBLL.Guardar(moras);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void AgregarBoton_Click(object sender, RoutedEventArgs e)
        {
            Contexto context = new Contexto();
            moras.Total += Convert.ToDecimal(ValorTextBox.Text);
            moras.MorasDetalle.Add(new MorasDetalle(moras.MoraId, Convert.ToInt32(PrestamoIDComboBox.SelectedValue), Convert.ToDecimal(ValorTextBox.Text)));
            

            this.DataContext = null;
            this.DataContext = moras;

            ValorTextBox.Clear();
        }

        private void RemoverBoton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                MorasDetalle mora = (MorasDetalle)DetalleDataGrid.SelectedValue;
                moras.Total -= mora.Valor;
                moras.MorasDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                this.DataContext = null;
                this.DataContext = moras;
            }
        }
        private bool Existe()
        {
            Moras esValido = MorasBLL.Buscar(moras.MoraId);

            return (esValido != null);
        }
    }
    }