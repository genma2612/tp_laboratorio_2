using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Métodos

        /// <summary>
        /// Inserta un paquete en la base de datos.
        /// </summary>
        /// <param name="p">Paquete a ingresar.</param>
        /// <returns>Verdadero si pudo ser guardado, falso si no.</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                PaqueteDAO.comando.CommandText = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) " +
                    "VALUES ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Manuel Gonzalez 2A");
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                retorno = false;
                throw e;
            }
            finally
            {
                if (retorno)
                    PaqueteDAO.conexion.Close();
            }
            return retorno;
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor que inicializa la conexión y el comando.
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }
        #endregion
    }
}
