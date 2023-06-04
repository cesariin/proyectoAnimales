using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Mi_granjita
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RecuperarDatos();
        }

        public void RecuperarDatos()
        {
            List<Animales> animalitos=new List<Animales>();
            SqlConnection conexion = new SqlConnection(Compartir.CONNECTION_STRING);
            conexion.Open();
            string consulta = "SELECT Id, Nombre_del_Animal, Especie, Raza, Crias, Vacunas FROM Animalitos";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) 
            {
                while (reader.Read())
                {
                    animalitos.Add(new Animales
                    {
                        Id = reader.GetInt32(0),
                        Nombre_del_Animal = reader.GetString(1),
                        Especie = reader.GetString(2),
                        Raza = reader.GetString(3),
                        Crias = reader.GetInt32(4),
                        Vacunas = reader.GetString(5)

                    });
                }
            }
            grilla.ItemsSource = animalitos;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }



    }
}

