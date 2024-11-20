
using Pearmageddon.Models;
using Pearmageddon.Objects;

namespace Pearmageddon.ExtensionMethods
{
    public static class PearTypeExtension
    {
        public static PearType ToDataObject(this PearTypeModel model)
        {
            return new PearType
            {
                ID = model.ID,
                Name = model.Name,
                Color = model.Color,
                Timestamp = model.Timestamp ?? DateTime.Now
            };
        }
        public static PearTypeModel ToModel(this PearType pearType)
        {
            return new PearTypeModel
            {
                ID = pearType.ID,
                Name = pearType.Name,
                Color = pearType.Color
            };
        }
    }
}
