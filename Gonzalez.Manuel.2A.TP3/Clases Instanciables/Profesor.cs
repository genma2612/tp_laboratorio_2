using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        /// <summary>
        /// Muestra los datos de Profesor.
        /// </summary>
        /// <returns>Cadena con datos de Profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Genera una cadena con los datos de Profesor.
        /// </summary>
        /// <returns>Cadena con datos de Profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine(this.ParticiparEnClase());
            return retorno.ToString();
        }

        /// <summary>
        /// Igualdad entre Profesor y EClase si el profesor dicta esa clase.
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el profesor dicta la clase, false si no.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            if (i._clasesDelDia.Contains(clase))
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Desigualdad entre Profesor y EClase si el profesor no dicta esa clase.
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el profesor dicta la clase, false si no.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Muestra las clases que dictará el profesor en el día.
        /// </summary>
        /// <returns>Cadena con las clases que dictará el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("CLASES DEL DÍA");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                retorno.AppendLine(item.ToString());
            }
            return retorno.ToString();
        }

        /// <summary>
        /// Genera EClases al azar.
        /// </summary>
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)(Profesor._random.Next(0, 4)));
        }

        /// <summary>
        /// Constructor estático que inicializa el atributo Random.
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
    }
}
