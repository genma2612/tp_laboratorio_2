using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario :Persona
    {
        private int _legajo;

        /// <summary>
        /// Compara una instancia con el tipo "Universitario".
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj.GetType() == this.GetType())
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Muestra los datos de Universitario.
        /// </summary>
        /// <returns>Cadena con la información de Universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ToString());
            retorno.AppendFormat("LEGAJO NÚMERO: {0}\n", this._legajo);
            return retorno.ToString();
        }

        /// <summary>
        /// Compara dos universitarios por tipo y por DNI o Legajo.
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>Verdadero si son iguales, falso si son distintos.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo))
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Compara dos universitarios por tipo y por DNI o Legajo.
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>Verdadero si son distintos, falso si son iguales.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Constuctor con parametros.
        /// </summary>
        /// <param name="legajo">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
    }
}
