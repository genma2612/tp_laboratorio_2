using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestsUnitarios
{
    [TestClass]
    public class TestsCorreo
    {

        /// <summary>
        /// Comprueba que la lista de paquetes de Correo esté instanciada.
        /// </summary>
        [TestMethod()]
        public void ListaCorreoInstanciada()
        {
            Correo correo = new Correo();
            Paquete paquete = new Paquete("Mitre", "999-999-9999");
            try
            {
                correo.Paquetes.Add(paquete);
                Assert.IsNotNull(correo.Paquetes);
            }
            catch (ArgumentNullException)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Verifica que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod()]
        public void PaqueteDuplicado()
        {
            Correo correo = new Correo();
            Paquete P1 = new Paquete("Mitre", "999-999-9999");
            Paquete P2 = new Paquete("Belgrano", "999-999-9999");         
            correo += P1;
            try
            {
                correo += P2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
            
        }
    }
}
