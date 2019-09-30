using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using Mobin.Common.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kendo.Mvc.Mobin.DataAnnotations.Internal
{
    public class MobinValidatiomAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        IValidationAttributeAdapterProvider baseProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is NationalCodeAttribute)
                return new NationalCodeAttributeAdapter(attribute as NationalCodeAttribute, stringLocalizer);
            else
                return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}