namespace MXGP.Core
{
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;

    public abstract class RiderFactory
    {

        public static IRider CreateRider(string riderName)
        {
            IRider rider = new Rider(riderName);

            return rider;
        }

    }
}
