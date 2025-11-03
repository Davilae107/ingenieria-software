using NUnit.Framework;
using Cafetera.Domain;

namespace Cafetera.Tests
{
    [TestFixture]
    public class TestCafetera
    {
        [Test]
        public void DeberiaDevolverVerdaderoSiExisteCafe()
        {
            // Arrange
            Domain.Cafetera cafetera = new Domain.Cafetera(10);
            
            // Act
            bool resultado = cafetera.HasCafe(5);
            
            // Assert
            Assert.That(resultado, Is.True);
        }

        [Test]
        public void DeberiaDevolverFalsoSiNoExisteCafe()
        {
            // Arrange
            Domain.Cafetera cafetera = new Domain.Cafetera(10);
            
            // Act
            bool resultado = cafetera.HasCafe(11);
            
            // Assert
            Assert.That(resultado, Is.False);
        }

        [Test]
        public void DeberiaRestarCafeALaCafetera()
        {
            // Arrange
            Domain.Cafetera cafetera = new Domain.Cafetera(10);
            
            // Act
            cafetera.GiveCafe(7);
            
            // Assert
            Assert.That(cafetera.GetCantidadCafe(), Is.EqualTo(3));
        }
    }
}
