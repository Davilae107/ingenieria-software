using NUnit.Framework;
using Cafetera.Domain;

namespace Cafetera.Tests
{
    [TestFixture]
    public class TestAzucarero
    {
        private Azucarero azucarero;

        [SetUp]
        public void Setup()
        {
            azucarero = new Azucarero(10);
        }

        [Test]
        public void DeberiaDeolverVerdaderoSiHaySuficienteAzucarEnElAzucarero()
        {
            // Act & Assert
            bool resultado = azucarero.HasAzucar(5);
            Assert.That(resultado, Is.True);
            
            resultado = azucarero.HasAzucar(10);
            Assert.That(resultado, Is.True);
        }

        [Test]
        public void DeberiaDevolverFalsoPorqueNoHaySuficienteAzucarEnElAzucarero()
        {
            // Act
            bool resultado = azucarero.HasAzucar(15);
            
            // Assert
            Assert.That(resultado, Is.False);
        }

        [Test]
        public void DeberiaRestarAzucarAlAzucarero()
        {
            // Act & Assert
            azucarero.GiveAzucar(5);
            Assert.That(azucarero.GetCantidadAzucar(), Is.EqualTo(5));
            
            azucarero.GiveAzucar(2);
            Assert.That(azucarero.GetCantidadAzucar(), Is.EqualTo(3));
        }
    }
}
