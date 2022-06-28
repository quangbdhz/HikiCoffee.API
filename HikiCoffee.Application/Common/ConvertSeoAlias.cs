using System.Text;
using System.Text.RegularExpressions;

namespace HikiCoffee.Application.Common
{
    public class ConvertSeoAlias : IConvertSeoAlias
    {
        public string GetSeoAlias(string value)
        {
            Random rd = new Random();

            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = value.Normalize(NormalizationForm.FormD);
            value = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            Regex trimmer = new Regex(@"\s\s+");

            value = trimmer.Replace(value, " ");
            value = "/" + value.Replace(" ", "-") + "-" + rd.Next(100000, 999999);

            return value.ToLower();
        }
    }
}
