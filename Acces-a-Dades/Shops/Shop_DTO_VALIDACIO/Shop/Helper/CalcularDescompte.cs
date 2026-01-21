using dbdemo.Model;

namespace dbdemo.Services
{
    public static class CalculsCarro
    {
        public static decimal Calcular(List<ImportAndCo> productes)
        {
            decimal import = 0;

            foreach (ImportAndCo producte in productes)
            {
                import += producte.Quantitat * producte.Price;
            }


           return import;
        }
    }
}
