using Gtf.Entity;
using Gtf.Interfaces;
using System;

namespace Gtf.Implementations
{
    public class MealFactory : IMealFactory
    {
        public virtual IMeal CreateMeal(IMyContext db, string period)
        {
            IMeal meal = null;

            switch (period)
            {
                case "manhã":
                case "manha":
                    meal = new DayMeal(db);
                    break;
                case "noite":
                    meal = new NightMeal(db);
                    break;
                default:
                    throw new ArgumentException("Pedido inválido");
            }

            return meal;
        }
    }
}
