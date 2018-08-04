using System;
using System.Linq;
using Gtf.Entity;
using Gtf.Interfaces;

namespace Gtf.Implementations
{
    public class NightMeal : BaseMeal, IMeal
    {
        public NightMeal(IMyContext db)
        {
            Period = db.GetFirstPeriod("noite");
        }

        public Period Period { get; set; }

        public string MakeResponse(IMyContext db, string[] request)
        {            
            var repeatedItem = new Tuple<int, string>(2, "batata");
            var pedidoAux = request.Skip(1).OrderBy(x => x).ToArray();
            var result = "";
            Array.Sort((Array)pedidoAux);
            var repeatedQuantity = 1;
            for (var i = 1; i < request.Length; i++)
            {
                request[i] = pedidoAux[i - 1];

                var typeId = Convert.ToInt16(request[i]);
                var mealDescription = db.GetMealDescription(typeId, Period.Id);

                if (i > 1 && typeId != repeatedItem.Item1)
                {
                    result += ", ";
                }
                else if (typeId == repeatedItem.Item1 && !result.Contains(mealDescription))
                {
                    result += ", ";
                }

                if (!result.Contains(mealDescription))
                {
                    result += mealDescription;
                }
                else if (repeatedItem.Item1 == typeId)
                {
                    repeatedQuantity++;
                }
            }

            return FormatResult(result, repeatedItem, repeatedQuantity);
        }
    }
}
