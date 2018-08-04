using Gtf.Entity;

namespace Gtf.Interfaces
{
    public interface IMeal
    {
        string MakeResponse(IMyContext db, string[] pedidoSplit);
    }
}