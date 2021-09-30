using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioRepasoParcial2
{
    public class Producto
    {

        #region Atributos
        private int id;
        private string codigo;
        private string descripcion;
        private string rubro;
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }
        #endregion


        #region Constructores
        public Producto()
        {

        }
        public Producto(
            int pId, 
            string pCodigo, 
            string pDescripcion, 
            string pRubro)
        {
            Id = pId;
            Codigo = pCodigo;
            Descripcion = pDescripcion;
            Rubro = pRubro;
        }
        #endregion


        #region Metodos
        static public DataTable BuscarTodo()
        {
            string sentenciaSQL = "SELECT * FROM Producto";
            DataTable dt = BaseDatos.Buscar(sentenciaSQL);
            return dt;
        }

        static public DataTable BuscarCodigo(string texto)
        {
            string sentenciaSQL = $"SELECT * FROM Producto WHERE Codigo LIKE '%{texto}%'";
            DataTable dt = BaseDatos.Buscar(sentenciaSQL);
            return dt;
        }

        static public DataTable BuscarDescripcion(string texto)
        {
            string sentenciaSQL = $"SELECT * FROM Producto WHERE Descripcion LIKE '%{texto}%'";
            DataTable dt = BaseDatos.Buscar(sentenciaSQL);
            return dt;
        }

        static public bool Eliminar(int id)
        {
            string sentenciaSQL = $"DELETE FROM Producto WHERE Id = {id}";
            return BaseDatos.EjecutarConsulta(sentenciaSQL);
        }

        public bool Nuevo()
        {
            string sentenciaSQL = $"INSERT INTO Producto (Codigo, Descripcion, Rubro) VALUES ('{Codigo}','{Descripcion}','{Rubro}')";
            return BaseDatos.EjecutarConsulta(sentenciaSQL);
        }

        public bool Modificar()
        {
            string sentenciaSQL = $"UPDATE Producto SET Codigo = '{Codigo}', Descripcion = '{Descripcion}', Rubro = '{Rubro}' WHERE Id = {Id}";
            return BaseDatos.EjecutarConsulta(sentenciaSQL);
        }

        #endregion






    }
}
