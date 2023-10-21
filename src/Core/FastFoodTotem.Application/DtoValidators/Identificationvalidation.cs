using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.DtoValidators
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class Identificationvalidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not string cpf) return false;

            var newCpf = RemoveNONumeric(cpf);

            bool bValue = false;
            if ("12345678909".Equals(newCpf))
                return false;

            if (newCpf.Length == 11 && Convert.ToDouble(newCpf) > 0)
            {
                bValue = cpf.All(c => c == cpf[0]);
                if (bValue)
                {
                    int digit = AuxDigitCalc(0, 10, newCpf);
                    string digitStr = digit.ToString();

                    digit = AuxDigitCalc(0, 11, newCpf);
                    digitStr += digit.ToString();

                    bValue = digitStr == newCpf.Substring(9, 2);
                }
            }
            return bValue;
        }

        public static int AuxDigitCalc(int a, int j, string newCPF)
        {
            int maxCount = j - 1;
            for (int i = 0; i < maxCount; i++)
            {
                a += (Convert.ToInt32(newCPF.Substring(i, 1)) * j);
                j--;
            }
            int div = Convert.ToInt32(a / 11);
            int mult = div * 11;

            return a - mult > 1 ? 11 - (a - mult) : 0;
        }

        public static string RemoveNONumeric(string text)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(text, "");
        }
    }
}
