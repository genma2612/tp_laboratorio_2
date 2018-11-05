using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        /// <summary>
        /// Nacionalidad (Argentino, Extranjero)
        /// </summary>
        public enum ENacionalidad { Argentino, Extranjero };

        private int _dni;  
        private string _nombre;
		private string _apellido;
		private ENacionalidad _nacionalidad;

        /// <summary>
        /// DNI de la persona.
        /// </summary>
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                if (!(string.IsNullOrWhiteSpace(this.ValidarNombreApellido(value))))
                    this._nombre = value;
            }
        }

        /// <summary>
        /// Apellido de la persona.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                if(!(string.IsNullOrWhiteSpace(this.ValidarNombreApellido(value))))
                    this._apellido = value;
            }
        }

        /// <summary>
        /// Nacionalidad de la persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                if(value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
                    this._nacionalidad = value;
            }
        }

        /// <summary>
        /// Convierte, de ser posible, una cadena a DNI en formato int.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Convierte a string los datos de Persona.
        /// </summary>
        /// <returns>Cadena con datos de Persona.</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            retorno.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return retorno.ToString();
        }

        /// <summary>
        /// Valida DNI segun nacionalidad y numero.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns>DNI en formato integer.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            try
            {
                if ((nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999)) ||
                    (nacionalidad == ENacionalidad.Extranjero && (dato < 90000000 || dato > 99999999)))
                    throw new NacionalidadInvalidaException();
                else
                    return dato;
            }
            catch (NacionalidadInvalidaException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Valida DNI segun nacionalidad y numero.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns>DNI en formato integer.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                if (int.TryParse(dato, out int dni) && dni > 0 && dni <= 99999999)
                    return ValidarDni(nacionalidad, dni);
                else
                    throw new DniInvalidoException();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Valida que el nombre/apellido no contenga caracteres inválidos.
        /// </summary>
        /// <param name="dato">Cadena a validar</param>
        /// <returns>Nombre o apellido si es válido, cadena vacia si no lo es.</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool validacion = true;
            foreach (char item in dato)
            {
                if (!char.IsLetter(item))
                {
                    validacion = false;
                    break;
                }
            }
            if (validacion == true)
                return dato;
            else
                return "";
        }
    }
}
