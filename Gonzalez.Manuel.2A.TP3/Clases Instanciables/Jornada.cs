using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        /// <summary>
        /// List de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        /// <summary>
        /// Clase de la jornada.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }

        /// <summary>
        /// Instructor de la jornada.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }

        /// <summary>
        /// Guarda la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>True si se puedo guardar correctamente, caso contrario False.</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto T = new Texto();
            if (T.Guardar("Jornada.txt", jornada.ToString()))
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Lee un archivo de texto.
        /// </summary>
        /// <returns>Cadena con el contenido del archivo.</returns>
        public string Leer()
        {
            Texto T = new Texto();
            if (T.Leer("Jornada.txt", out string dato))
            {
                return dato;
            }
            return "";
        }

        /// <summary>
        /// Genera cadena con el contenido de la jornada.
        /// </summary>
        /// <returns>Cadena con el contenido de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("CLASE DE " + this.Clase + " POR ");
            retorno.Append(this.Instructor.ToString());
            retorno.Append("ALUMNOS:");
            foreach (Alumno item in this.Alumnos)
            {
                retorno.AppendLine(item.ToString());
            }
            return retorno.ToString();
        }

        /// <summary>
        /// Agrega un alumno a la jornada si éste toma la clase.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Jornada.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
                j._alumnos.Add(a);
            return j;
        }

        /// <summary>
        /// Igualdad entre Jornada y Alumno si el alumno toma la clase de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>True si el alumno toma la clase, False si no.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            if (a == j.Clase)
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Desigualdad entre Jornada y Alumno si el alumno no toma la clase de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>True si el alumno no toma la clase, False si la toma.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Constructor privado que inicializa la lista de Alumnos.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="clase">Clase</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

    }
}
