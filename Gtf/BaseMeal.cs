using System;
using System.Linq;

namespace Gtf
{
    public abstract class BaseMeal
    {
        protected string FormatResult(string result, Tuple<int, string> repeatedItem, int repeatedQuantity)
        {
            var resultSplit = result.Split(new[] { ", " }, StringSplitOptions.None);
            result = string.Empty;
            for (var i = 0; i < resultSplit.Length; i++)
            {
                if (resultSplit[i] == repeatedItem.Item2)
                {
                    result += resultSplit[i] + (repeatedQuantity == 1 ? "" : " (x" + repeatedQuantity + ")");
                }
                else
                {
                    result += resultSplit[i];
                }

                if (result.Split(',').Length < 4 && result.Last() != ' ')
                {
                    result += ", ";
                }
            }

            if (result.Last() == ' ')
            {
                result = result.Substring(0, result.Length - 2);
            }

            return result;
        }
    }
}
