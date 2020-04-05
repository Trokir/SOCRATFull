using System.Collections.Generic;

namespace Socrat.Common.Enums
{
    public class EnumHelper
    {
        /// <summary>
        /// Возвращает список возможных значений для энумератора CharacterSets
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<string, CharacterSets>> GetCharacterSets()
        {
            List<KeyValuePair<string, CharacterSets>> res = new List<KeyValuePair<string, CharacterSets>>();
            res.Add(new KeyValuePair<string, CharacterSets>("Любые", CharacterSets.Any));
            res.Add(new KeyValuePair<string, CharacterSets>("Только латиница", CharacterSets.LatinOnly));
            return res;
        }

        /// <summary>
        /// Возвращает список возможных значений для энумератора CapitalizationModes
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<string, CapitalizationModes>> GetCapitalizationModes()
        {
            List<KeyValuePair<string, CapitalizationModes>> res = new List<KeyValuePair<string, CapitalizationModes>>();
            res.Add(new KeyValuePair<string, CapitalizationModes>("Любые", CapitalizationModes.AnyCase));
            res.Add(new KeyValuePair<string, CapitalizationModes>("Только прописные", CapitalizationModes.LowerCaseOnly));
            res.Add(new KeyValuePair<string, CapitalizationModes>("Только строчные", CapitalizationModes.UpperCaseOnly));
            return res;
        }

        /// <summary>
        /// Возвращает список возможных значений для энумератора StringCharacterTypes
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<string, StringCharacterTypes>> GetStringCharacterTypes()
        {
            List<KeyValuePair<string, StringCharacterTypes>> res = new List<KeyValuePair<string, StringCharacterTypes>>();
            res.Add(new KeyValuePair<string, StringCharacterTypes>("Любые", StringCharacterTypes.Any));
            res.Add(new KeyValuePair<string, StringCharacterTypes>("Только буквы", StringCharacterTypes.Letters));
            res.Add(new KeyValuePair<string, StringCharacterTypes>("Только цифры", StringCharacterTypes.Digits));
            res.Add(new KeyValuePair<string, StringCharacterTypes>("Только цифры и буквы", StringCharacterTypes.DigitsOrLetters));
            return res;
        }

        /// <summary>
        /// Возвращает список возможных значений для энумератора TransformationRules
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<string, TransformationRules>> GetTransformationRules()
        {
            List<KeyValuePair<string, TransformationRules>> res = new List<KeyValuePair<string, TransformationRules>>();
            res.Add(new KeyValuePair<string, TransformationRules>("Не установлен", TransformationRules.Unknown));
            res.Add(new KeyValuePair<string, TransformationRules>("Поля GLASSn файла TRF для GPSOpt", TransformationRules.GpsOptTrfOptGlass));
            res.Add(new KeyValuePair<string, TransformationRules>("Поля FRAMEn файла TRF для GPSOpt", TransformationRules.GpsOptTrfOptFrame));
            return res;
        }
    }
}
