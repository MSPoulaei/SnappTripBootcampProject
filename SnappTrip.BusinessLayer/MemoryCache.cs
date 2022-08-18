using SnappTrip.DataAccessLayer.Models;

namespace SnappTrip.BusinessLayer
{
    public static class MemoryCache
    {
        public static List<RCA> RCAs = null;
        public static DateTime lastRequestTime;

    }
}
