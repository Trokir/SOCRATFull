using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Socrat.Parser
{
    public class ParseType
    {
        public string Alias { get; set; }
        public string Description { get; set; }
    }

    public static class ParseTypes
    {
        private static List<ParseType> parseTypes =
            new List<ParseType>
            {
                new ParseType
                {
                    Alias = "REPLACE",
                    Description = "Замена символов исходной последовательности ParseStr на последовательность ValueStr"
                },
                new ParseType
                {
                    Alias = "FILTER_GROUP",
                    Description =
                        @"Применение регулярного выражения (фильтра) - регулярное выражение задаётся параметром ParseStr, " +
                        "результат определяется номером подгруппы, указанном в ValueStr " +
                        "(однократное выполнение Exec и результат в Math[ValueStr])"
                },
                new ParseType
                {
                    Alias = "FILTER_ITERATION",
                    Description =
                        @"Применение регулярного выражения (фильтра) - регулярное выражение задаётся параметром ParseStr, " +
                                "результат определяется номером результата, указанном в ValueStr " + 
                                "(ValueStr-кратное выполнение Exec и результат в Math[0])"
                },
                new ParseType
                {
                    Alias = "MAKE_FORMULA",
                    Description = "Сборка значения по формуле, указанной в <Details Formula='[1]'>"
                },
                new ParseType
                {
                    Alias = "FIX_VALUE",
                    Description = "Замена символов исходной последовательности на указанное значение"
                },
                new ParseType
                {
                    Alias = "SET_GAZ",
                    Description = "Вставка аргона перед энергосберегающими стёклами"
                },
                new ParseType
                {
                    Alias = "MEMORY",
                    Description = @"Запоминание значения последней не пустой ячейки и использование этого значения " +
                                 "для следующих ячеек если они пустые"
                }
            };


        public static List<string> ParseTypesList
        {
            get { return parseTypes.Select(x => x.Alias).ToList(); }

        }

        public static string GetDesc(string alias)
        {
            return parseTypes.FirstOrDefault(x => x.Alias == alias)?.Description;
        }

        public static string Parse(string alias, string parseStr, string valueStr, string sourceStr)
        {
            string res = sourceStr;
            Regex _regex = new Regex(parseStr);
            int i;
            switch (alias)
            {
                case "REPLACE":
                    res = _regex.Replace(sourceStr, valueStr);
                    break;
                case "FILTER_GROUP":
                case "FILTER_ITERATION":
                    i = 0;
                    int.TryParse(valueStr, out i);
                    if (_regex.IsMatch(sourceStr) && i < _regex.Matches(sourceStr).Count)
                        res = _regex.Matches(sourceStr)[i].Value;
                    break;
                case "FIX_VALUE":
                    res = valueStr;
                    break;
            }

            return res;
        }
    }


      
}