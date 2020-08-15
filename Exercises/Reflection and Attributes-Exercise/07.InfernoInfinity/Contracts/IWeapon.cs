namespace _07.InfernoInfinity
{
    using System.Collections.Generic;
    public interface IWeapon
    {
        string Name { get; }
        int MinimumDamage { get; }
        int MaximumDamage { get; }
        int SocketsCount { get; }
        GemsColection GemsColection { get; }
    }
}
