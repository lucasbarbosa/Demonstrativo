using Gtf.Entity;

namespace Gtf.Interfaces
{
    public interface IMealFactory
    {
        IMeal CreateMeal(IMyContext db, string period);
    }
}
