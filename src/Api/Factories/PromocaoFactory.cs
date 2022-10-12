using Api.Models.Promocoes;
using System;

namespace Api.Factories
{
    public class PromocaoFactory : Creator
    {
        public override IPromotion FactoryMethod(string codigoPromocao)
        {
            if (string.Equals(codigoPromocao, "trespordez", StringComparison.OrdinalIgnoreCase) || string.Equals(codigoPromocao, "3por10", StringComparison.OrdinalIgnoreCase)) {
                return new TresPorDez();
            }

            else if (string.Equals(codigoPromocao, "levedoispagueum", StringComparison.OrdinalIgnoreCase) || string.Equals(codigoPromocao, "leve2pague1", StringComparison.OrdinalIgnoreCase))
            {
                return new LeveDoisPagueUm();
            }
            else
            {
                throw new ArgumentException("Promoção não encontrada");
            }
        }
    }
}
