using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        /// <summary>
        /// List de alumnos.
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
        /// List de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this._profesores;
            }
            set
            {
                this._profesores = value;
            }
        }

        /// <summary>
        /// List de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }
            set
            {
                this._jornada = value;
            }
        }

        /// <summary>
        /// Indexador de jornadas.
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>Jornada en el indice ingresado.</returns>
        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }
            set
            {
                this._jornada[i] = value;
            }
        }

        /// <summary>
        /// Guarda Universidad en un archivo xml.
        /// </summary>
        /// <param name="uni">Universidad a guardar</param>
        /// <returns>True si se pudo guardar, false en caso de error.</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            if (xml.Guardar("Universidad.xml", uni))
                retorno = true;
            return retorno;
        }
        
        /// <summary>
        /// Lee un archivo xml.
        /// </summary>
        /// <returns>Cadena con el contenido si el archivo pudo leerse, vacia en caso contrario.</returns>
        public string Leer()
        {
            string retorno = "";
            Xml<Universidad> xml = new Xml<Universidad>();
            if (xml.Leer("Universidad.xml", out Universidad dato))
                retorno = dato.ToString();
            return retorno;
        }

        /// <summary>
        /// Muestra los datos de Universidad.
        /// </summary>
        /// <returns>Cadena con los datos.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Genera cadena con los datos de Universidad-
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Cadena con los datos.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.Jornadas)
            {
                retorno.AppendLine(jornada.ToString());
                retorno.AppendLine("<------------------------------------------------------------------>\n");
            }
            return retorno.ToString();
        }

        /// <summary>
        /// Se agrega un alumno a la universidad si éste no se encuentra actualmente en ella.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad.</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            g.Alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Se agrega un profesor a la universidad si éste no se encuentra actualmente en ella.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if(g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }

        /// <summary>
        /// Se agrega una clase a la universidad si existe un profesor que pueda dictar la materia.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Materia</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = new Profesor();
            profesor = (g == clase);
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno estudiante in g.Alumnos)
            {
                if (estudiante == clase)
                {
                    jornada += estudiante;
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        /// <summary>
        /// Alumno es igual a universidad si éste se encuentra en ella.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno está en la universidad, false si no lo está.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }          
            }
            return retorno;
        }

        /// <summary>
        /// Alumno es desigual a universidad si éste no se encuentra en ella.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno no está en la universidad, false si lo está.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Profesor es igual a universidad si éste da clases en ella.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True si el profesor está en la universidad, false si no lo está.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                    retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Profesor es desigual a universidad si éste no da clases en ella.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True si el profesor no está en la universidad, false si lo está.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Universidad es igual a clase si cuenta con un profesor que dicte esa clase.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor que dicte la clase si lo hubiese.</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Universidad es desigual a clase si cuenta con un profesor que no dicte esa clase.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Profesor que no dicte la clase si lo hubiese.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor instructor in g.Instructores)
            {
                if (instructor != clase)
                {
                    return instructor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Constructor por defecto que inicializa las listas.
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }

    }
}
