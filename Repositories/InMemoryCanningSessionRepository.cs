using Microsoft.Extensions.Caching.Memory;
using Pearmageddon.Objects;

namespace Pearmageddon.Repositories
{
    public class InMemoryCanningSessionRepository : ICanningSessionRepository
    {
        private const string _CacheKey = "CanningSessions";
        private readonly IMemoryCache _Cache;
        public InMemoryCanningSessionRepository(IMemoryCache cache) 
        {
            _Cache = cache;
        }
        public CanningSession Get(int id)
        {
            var sessions = _Cache.Get<IEnumerable<CanningSession>>(_CacheKey);
            
            return sessions?.FirstOrDefault(session => session.ID == id);

        }

        public IEnumerable<CanningSession> GetAll()
        {
            var sessions = _Cache.Get<IEnumerable<CanningSession>>(_CacheKey);
            if(sessions == null)
            {
                sessions = new List<CanningSession>();
            }
            return sessions;
        }

        public void Save(CanningSession canningSession)
        {
            var sessions = _Cache.Get<IEnumerable<CanningSession>>(_CacheKey)?.ToList();
            if(sessions == null)
            {
                sessions = new List<CanningSession>();
            }
            if(canningSession.ID.HasValue)
            {
                var existingSession = sessions.FirstOrDefault(session => session.ID == canningSession.ID);
                if(existingSession != null)
                {
                    sessions.Remove(existingSession);
                }
            }
            else
            {
                canningSession.ID = sessions.Max(session => session.ID).GetValueOrDefault() + 1;
            }
            sessions.Add(canningSession);
            _Cache.Set(_CacheKey, sessions);
        }
    }
}
