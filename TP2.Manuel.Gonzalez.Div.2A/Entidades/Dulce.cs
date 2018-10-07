using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Propiedades
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Genera una string de los parametros de la clase base y la heredada.
        /// </summary>
        /// <param name="p"></param>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\r\n", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Constructor
        public Dulce(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
        {
        }
        #endregion
    }
}
