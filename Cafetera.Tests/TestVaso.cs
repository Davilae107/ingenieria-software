using NUnit.Framework;
using Cafetera.Domain;

namespace Cafetera.Tests
{
    [TestFixture]
    public class TestVaso
    {
        [Test]
        public void DeberiaDevolverVerdaderoSiExistenVasos()
        {
            // Arrange
            Vaso vasosPequenos = new Vaso(2, 10);
            
            // Act
            bool resultado = vasosPequenos.HasVasos(1);
            
            // Assert
            Assert.That(resultado, Is.True);
        }

        [Test]
        public void DeberiaDevolverFalsoSiNoExistenVasos()
        {
            // Arrange
            Vaso vasosPequenos = new Vaso(1, 10);
            
            // Act
            bool resultado = vasosPequenos.HasVasos(2);
            
            // Assert
            Assert.That(resultado, Is.False);
        }

        [Test]
        public void DeberiaRestarCantidadDeVaso()
        {
            // Arrange
            Vaso vasosPequenos = new Vaso(5, 10);
            
            // Act
            vasosPequenos.GiveVasos(1);
            
            // Assert
            Assert.That(vasosPequenos.GetCantidadVasos(), Is.EqualTo(4));
        }
    }
}
