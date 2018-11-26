using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Delegado/Evento
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Enumerados
        public enum EEstado { Ingresado, EnViaje, Entregado }
        #endregion

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Atributos

        /// <summary>
        /// Dirección de entrega.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Estado.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Tracking ID.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Cambia el estado del paquete cada 4 segundos hasta que éste sea
        /// "Entregado".
        /// </summary>
        public void MockCicloDeVida()
        {
            
            do
            {
                Thread.Sleep(4000);
                this.Estado++;
                InformaEstado(this, new EventArgs());
            } while (this.Estado != EEstado.Entregado);
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Muestra los datos.
        /// </summary>
        /// <param name="elemento">Elemento</param>
        /// <returns>Cadena con la informacion de elemento.</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Igualdad entre paquetes por TrackingID
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">Paquete</param>
        /// <returns>Verdadero si sus Tracking ID son iguales, falso si no lo son.</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Desgualdad entre paquetes por TrackingID
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">Paquete</param>
        /// <returns>Falso si sus Tracking ID son iguales, Verdadero si no lo son.</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Convierte la información de Paquete a string.
        /// </summary>
        /// <returns>Cadena con información de Paquete.</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor que recibe parametros.
        /// </summary>
        /// <param name="direccionEntrega">Dirección de Entrega.</param>
        /// <param name="trackingID">Tracking ID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion
    }
}
