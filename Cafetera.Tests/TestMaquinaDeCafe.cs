using NUnit.Framework;
using Cafetera.Domain;

namespace Cafetera.Tests
{
    [TestFixture]
    public class TestMaquinaDeCafe
    {
        private Domain.Cafetera cafetera;
        private Vaso vasosPequeno;
        private Vaso vasosMediano;
        private Vaso vasosGrande;
        private Azucarero azucarero;
        private MaquinaDeCafe maquinaDeCafe;

        [SetUp]
        public void Setup()
        {
            cafetera = new Domain.Cafetera(50);
            vasosPequeno = new Vaso(5, 10);
            vasosMediano = new Vaso(5, 20);
            vasosGrande = new Vaso(5, 30);
            azucarero = new Azucarero(20);
            maquinaDeCafe = new MaquinaDeCafe();
            maquinaDeCafe.SetCafetera(cafetera);
            maquinaDeCafe.SetVasosPequeno(vasosPequeno);
            maquinaDeCafe.SetVasosMediano(vasosMediano);
            maquinaDeCafe.SetVasosGrande(vasosGrande);
            maquinaDeCafe.SetAzucarero(azucarero);
        }

        [Test]
        public void DeberiaDevolverUnVasoPequeno()
        {
            // Act
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            
            // Assert
            Assert.That(vaso, Is.EqualTo(maquinaDeCafe.GetVasosPequeno()));
        }

        [Test]
        public void DeberiaDevolverUnVasoMediano()
        {
            // Act
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("mediano");
            
            // Assert
            Assert.That(vaso, Is.EqualTo(maquinaDeCafe.GetVasosMediano()));
        }

        [Test]
        public void DeberiaDevolverUnVasoGrande()
        {
            // Act
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("grande");
            
            // Assert
            Assert.That(vaso, Is.EqualTo(maquinaDeCafe.GetVasosGrande()));
        }

        [Test]
        public void DeberiaDevolverNoHayVasos()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            
            // Act
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 10, 2);
            
            // Assert
            Assert.That(resultado, Is.EqualTo("No hay Vasos"));
        }

        [Test]
        public void DeberiaDevolverNoHayCafe()
        {
            // Arrange
            cafetera = new Domain.Cafetera(5);
            maquinaDeCafe.SetCafetera(cafetera);
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            
            // Act
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 2);
            
            // Assert
            Assert.That(resultado, Is.EqualTo("No hay Cafe"));
        }

        [Test]
        public void DeberiaDevolverNoHayAzucar()
        {
            // Arrange
            azucarero = new Azucarero(2);
            maquinaDeCafe.SetAzucarero(azucarero);
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            
            // Act
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            
            // Assert
            Assert.That(resultado, Is.EqualTo("No hay Azucar"));
        }

        [Test]
        public void DeberiaRestarCafe()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            
            // Act
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            int resultado = maquinaDeCafe.GetCafetera().GetCantidadCafe();
            
            // Assert
            Assert.That(resultado, Is.EqualTo(40)); // 50 iniciales - 10 de contenido
        }

        [Test]
        public void DeberiaRestarVaso()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            
            // Act
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            int resultado = maquinaDeCafe.GetVasosPequeno().GetCantidadVasos();
            
            // Assert
            Assert.That(resultado, Is.EqualTo(4)); // 5 iniciales - 1
        }

        [Test]
        public void DeberiaRestarAzucar()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            
            // Act
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            int resultado = maquinaDeCafe.GetAzucarero().GetCantidadAzucar();
            
            // Assert
            Assert.That(resultado, Is.EqualTo(17)); // 20 iniciales - 3
        }

        [Test]
        public void DeberiaDevolverFelicitaciones()
        {
            // Arrange
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            
            // Act
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            
            // Assert
            Assert.That(resultado, Is.EqualTo("Felicitaciones"));
        }
    }
}
