using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Mobin.Common.ComponentModel.DataAnnotations
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)] //Added
    public class NationalCodeAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = @"مقدار {0} باید معتبر باشد";

        /// <summary>
        /// Valiadtion for nationalcode attribute 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            try
            {
                if (value == null || value.ToString() == string.Empty)
                    return false;

                var input = value.ToString().ToArray();

                if (input.Length > 10)
                {
                    return false;
                }

                int result = 0, controlNr = (int)(input[9] - 48);
                for (int i = 0; i < input.Length - 1; i++)
                    result += (input[i] - 48) * (10 - i);

                int remainder = result % 11;
                bool isValid = controlNr == (remainder < 2 ? remainder : 11 - remainder);

                return isValid;
            }
            catch
            {
                return false;
            }
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
        //    ControllerContext context)
        //{
        //    if (string.IsNullOrEmpty(ErrorMessage))
        //        this.ErrorMessage = DefaultErrorMessage;
        //    var rule = new ModelClientValidationRule()
        //    {
        //        ValidationType = "nationalcode",
        //        ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
        //    };

        //    yield return rule;
        //}

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }
    }
}