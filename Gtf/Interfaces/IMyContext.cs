using Gtf.Entity;
using System;

namespace Gtf.Interfaces
{
    public interface IMyContext : IDisposable
    {
        Period GetFirstPeriod(string period);
        string GetMealDescription(int typeId, int periodId);
    }
}
