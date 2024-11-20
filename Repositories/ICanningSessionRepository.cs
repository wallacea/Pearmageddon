using Pearmageddon.Objects;

namespace Pearmageddon.Repositories
{
    public interface ICanningSessionRepository
    {
        CanningSession Get(int id);
        IEnumerable<CanningSession> GetAll();
        void Save(CanningSession canningSession);
    }
}
