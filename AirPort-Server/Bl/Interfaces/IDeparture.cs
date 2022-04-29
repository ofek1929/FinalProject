using Dal.Models;

namespace AirportServer.BL
{
    public interface IDeparture
    {
        public void Departe(Plane plane , IAirportLogic logic);
    }
}