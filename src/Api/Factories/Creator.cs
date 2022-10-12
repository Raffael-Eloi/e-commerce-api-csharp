using Api.Models.Promocoes;

namespace Api.Factories
{
    public abstract class Creator
    {
        public abstract IPromotion FactoryMethod(string className);
    }
}
