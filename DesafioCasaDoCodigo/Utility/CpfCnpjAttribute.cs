using Caelum.Stella.CSharp.Validation;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Utility
{
    public class CpfCnpjAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = value as string;

            CPFValidator cpfValidator = new CPFValidator();

            if (cpfValidator.IsValid(stringValue))
            {
                return true;
            }

            CNPJValidator cnpjValidator = new CNPJValidator();

            if (cnpjValidator.IsValid(stringValue))
            {
                return true;
            }

            return false;
        }
    }
}
