using Pearmageddon.Objects;

namespace Pearmageddon.Repositories
{
    public interface IPearTypeRepository
    {
        PearType Get(int id);
        IEnumerable<PearType> GetAll();
        void Save(PearType pearType);
    }
}
