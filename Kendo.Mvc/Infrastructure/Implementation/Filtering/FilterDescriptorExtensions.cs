namespace Kendo.Mvc.Infrastructure.Implementation
{
    using Kendo.Mvc.Extensions;
    using System.Collections.Generic;
    using System.Linq;

    public static class FilterDescriptorExtensions
    {
        internal static bool IsActive(this FilterDescriptor filter)
        {
            object value = filter.Value;
            if (value == null)
            {
                return false;
            }

            string valueAsString = value as string;
            return valueAsString == null || !string.IsNullOrEmpty(valueAsString);
        }

        public static IEnumerable<FilterDescriptor> SelectMemberDescriptors(this IEnumerable<IFilterDescriptor> descriptors)
        {
            return descriptors.SelectRecursive(f => GetChildDescriptors(f)).OfType<FilterDescriptor>();
        }

        private static IEnumerable<IFilterDescriptor> GetChildDescriptors(IFilterDescriptor f)
        {
            if (f is CompositeFilterDescriptor)
            {
                return ((CompositeFilterDescriptor)f).FilterDescriptors;
            }
            return null;
        }

        public static void SetMemberTypeFrom(this FilterDescriptor descriptor, object item)
        {
            if (!descriptor.Member.HasValue())
                return;

            descriptor.MemberType = BindingHelper.ExtractMemberTypeFromObject(item, descriptor.Member);
        }

        public static IEnumerable<IFilterDescriptor> SetMemberTypeFrom(this IEnumerable<IFilterDescriptor> descriptors, object item)
        {
            if (item != null)
            {
                descriptors.SelectMemberDescriptors()
                           .Each(f => f.SetMemberTypeFrom(item));
            }

            return descriptors;
        }
    }
}