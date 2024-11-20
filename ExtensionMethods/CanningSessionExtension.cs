
using Pearmageddon.Models;
using Pearmageddon.Objects;

namespace Pearmageddon.ExtensionMethods
{
    public static class CanningSessionExtension
    {
        public static CanningSession ToDataObject(this CanningSessionModel model)
        {
            return new CanningSession
            {
                ID = model.ID,
                DateCanned = model.DateCanned,
                PearTypeID = model.PearTypeID
                
            };
        }
        public static CanningSessionModel ToModel(this CanningSession canningSession)
        {
            return new CanningSessionModel
            {
                ID = canningSession.ID,
                DateCanned = canningSession.DateCanned,
                PearTypeID = canningSession.PearTypeID
            };
        }
    }
}
