namespace AquaShop.Core.Contracts
{
    public interface IFactory
    {
        object Create(params object[] value);

    }
}
