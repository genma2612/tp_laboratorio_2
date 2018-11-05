using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EntidadesInstanciables;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprueba Excepcion AlumnoRepetidoException.
        /// </summary>
        [TestMethod]
        public void AgregaAlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Carlos", "Garcia", "33258123",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "90234458",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
            Alumno a3 = new Alumno(2, "Juana", "Martinez", "90234458",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);

            // Agrego dos alumnos distintos.
            uni = uni + a1;
            uni += a2;

            try
            {
                // Alumno a2 es igual a a3
                uni += a3;
                Assert.Fail("Debería avisar que el alumno ya se encuentra");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Comprueba Excepcion DniInvalidoException.
        /// </summary>
        [TestMethod]
        public void DniInvalido()
        {
            try
            {
                Alumno a1 = new Alumno(1, "Carlos", "Garcia", "DNI8123",
                    EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                    Alumno.EEstadoCuenta.Becado);
                Assert.Fail("Debería avisar que el DNI es inválido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Corrobora que la lista está correctamente instanciada
        /// </summary>
        [TestMethod]
        public void JornadaNoEsNull()
        {
            Profesor profesor = new Profesor(1, "Juan", "Lopez", "12234456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);
            Assert.IsNotNull(jornada);
        }
        
        /// <summary>
        /// Comprueba la conversión de string DNI a int DNI.
        /// </summary>
        [TestMethod]
        public void ComprobacionConversionDNI()
        {
            Alumno a1 = new Alumno(1, "Carlos", "Garcia", "18999333",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            Assert.AreEqual(a1.DNI, 18999333);
        }
    }
}
