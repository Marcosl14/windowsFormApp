using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EjercicioRepasoParcial2
{
    public class BaseDatos
    {
        static SqlConnection conn = new SqlConnection();

        static private bool Conectar()
        {
            try
            {
                string baseDatos = "Parcial2";
                conn.ConnectionString = $"Data Source=.\\;Initial Catalog={baseDatos};Integrated Security=True";
                conn.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("No se pudo conectar a la BD");
                return false;
            }
        }

        static private void Desconectar()
        {
            conn.Close();
        }

        static public DataTable Buscar(string sentenciaSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sentenciaSQL, conn);
                da.Fill(dt);
            }
            catch
            {
                MessageBox.Show("No se encontraron coincidencias");
                return null;
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }

        static public bool EjecutarConsulta (string sentenciaSQL)
        {
            bool Correcto;
            try
            {
                Conectar();
                SqlDataAdapter da = new SqlDataAdapter(sentenciaSQL, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Correcto = true;
            }
            catch
            {
                Correcto = false;
            }
            finally
            {
                Desconectar();
            }
            return Correcto;
        }
    }
}
