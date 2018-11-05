using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado}

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        /// <summary>
        /// Muestra los datos de Alumno.
        /// </summary>
        /// <returns>Cadena con datos de Alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Genera cadena con los datos de Alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendFormat("ESTADO DE CUENTA: {0}\n", this._estadoCuenta);
            retorno.AppendLine(this.ParticiparEnClase());
            return retorno.ToString();
        }

        /// <summary>
        /// Igualdad entre Alumno y EClase si el alumno toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                retorno = true;
            return retorno;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        /// <summary>
        /// Retorna clases que toma el alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this._claseQueToma;
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Costructor parametrizado.
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        /// <param name="claseQueToma">Clase que toma.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, 
            Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Costructor parametrizado.
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        /// <param name="claseQueToma">Clase que toma.</param>
        /// <param name="estadoCuenta">Estado de cuenta.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this (id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
    }
}
