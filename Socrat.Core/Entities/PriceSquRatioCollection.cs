using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class PriceSquRatioCollection : HashSet<PriceSquRatio>
    {
        /// <summary>
        /// Возвращает подходящий коэффициент за заданную площадь
        /// </summary>
        /// <param name="forArea"></param>
        /// <returns></returns>
        public PriceSquRatio GetAppliedRatio(double forArea)
        {
            PriceSquRatio result = null;
            
            foreach (var ratio in this)
            {
                if (forArea == ratio.Squ)
                {
                    result = ratio;
                    break;
                }

                if (forArea < ratio.Squ)
                    continue;

                if (forArea > ratio.Squ)
                {
                    if (result == null)
                        result = ratio;
                    else
                    {
                        if (ratio.Squ < result.Squ)
                            result = ratio;
                    }

                }
            }

            return result;
        }
    }
}
