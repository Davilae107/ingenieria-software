namespace Cafetera.Domain
{
    public class MaquinaDeCafe
    {
        private Cafetera cafetera;
        private Vaso vasosPequenos;
        private Vaso vasosMedianos;
        private Vaso vasosGrandes;
        private Azucarero azucarero;

        public MaquinaDeCafe()
        {
        }

        public string GetVasoDeCafe(Vaso vaso, int cantidadVasos, int cantidadDeAzucar)
        {
            // 1. Validar existencia de vasos
            if (!vaso.HasVasos(cantidadVasos))
            {
                return "No hay Vasos";
            }

            // 2. Validar existencia de café
            int cafeNecesario = vaso.GetContenido() * cantidadVasos;
            if (!cafetera.HasCafe(cafeNecesario))
            {
                return "No hay Cafe";
            }

            // 3. Validar existencia de azúcar
            if (!azucarero.HasAzucar(cantidadDeAzucar))
            {
                return "No hay Azucar";
            }

            // 4. Si todo está OK, despachar y restar inventario
            vaso.GiveVasos(cantidadVasos);
            cafetera.GiveCafe(cafeNecesario);
            azucarero.GiveAzucar(cantidadDeAzucar);

            return "Felicitaciones";
        }

        public Vaso GetTipoDeVaso(string tipoDeVaso)
        {
            switch (tipoDeVaso)
            {
                case "pequeno":
                    return vasosPequenos;
                case "mediano":
                    return vasosMedianos;
                case "grande":
                    return vasosGrandes;
                default:
                    return null;
            }
        }

        // Setters
        public void SetCafetera(Cafetera cafetera)
        {
            this.cafetera = cafetera;
        }

        public void SetVasosPequeno(Vaso vasosPequeno)
        {
            this.vasosPequenos = vasosPequeno;
        }

        public void SetVasosMediano(Vaso vasosMediano)
        {
            this.vasosMedianos = vasosMediano;
        }

        public void SetVasosGrande(Vaso vasosGrande)
        {
            this.vasosGrandes = vasosGrande;
        }

        public void SetAzucarero(Azucarero azucarero)
        {
            this.azucarero = azucarero;
        }

        // Getters
        public Cafetera GetCafetera()
        {
            return cafetera;
        }

        public Vaso GetVasosPequeno()
        {
            return vasosPequenos;
        }

        public Vaso GetVasosMediano()
        {
            return vasosMedianos;
        }

        public Vaso GetVasosGrande()
        {
            return vasosGrandes;
        }

        public Azucarero GetAzucarero()
        {
            return azucarero;
        }
    }
}
