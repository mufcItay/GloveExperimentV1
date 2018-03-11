using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonTools
{
    public interface IValidatable
    {
        bool Validate();
    }

    public class GenericValidator <T> : IValidatable
    {
        T mValidatedObject;
        public GenericValidator(T obj)
        {
            mValidatedObject = obj;
        }

        public IEnumerable<PropertyInfo> GetInvalidPropertiesErrors()
        {
            var props = mValidatedObject.GetType().GetProperties();
            IList<PropertyInfo> invalidProperties = new List<PropertyInfo>();
            foreach (var prop in props)
            {
                if(!ValidateProperty(prop))
                {
                    invalidProperties.Add(prop);
                }
            }
            return invalidProperties;
        }

        private static bool ValidateRequieredRule(IEnumerable<object> attributes, object value)
        {
            IList<ValidatorAttribute> validatorAttrs = new List<ValidatorAttribute>();
            foreach (var item in attributes)
            {
                validatorAttrs.Add(item as ValidatorAttribute);
            }
            var requiered = validatorAttrs.Where(x => x.IsRequiered == true);
            if(!requiered.Any())
            {
                return true;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            return true;
        }

        private static bool ValidateRangeRule(IEnumerable<object> attributes, object value)
        {
            IList<ValidatorAttribute> validatorAttrs = new List<ValidatorAttribute>();
            foreach (var item in attributes)
            {
                validatorAttrs.Add(item as ValidatorAttribute);
            }
            var ranges = validatorAttrs.Where(x => (x.MinValue != double.MinValue || x.MaxValue != double.MaxValue));
            if (!ranges.Any())
            {
                return true;
            }

            bool isInSomeRange = false;

            foreach (var range in ranges)
            {
                // check is in range
                double doubleValue;
                if (!double.TryParse(value.ToString(), out doubleValue))
                {
                    return false;
                }
                if (range.MinValue <= doubleValue && range.MaxValue >= doubleValue)
                {
                    // in range
                    isInSomeRange = true;
                    break;
                }
            }
            return isInSomeRange;
        }


        private static bool ValidateRegexRule(IEnumerable<object> attributes, object value)
        {
            IList<ValidatorAttribute> validatorAttrs = new List<ValidatorAttribute>();
            foreach (var item in attributes)
            {
                validatorAttrs.Add(item as ValidatorAttribute);
            }
            var regexExpressions = validatorAttrs.Where(x => (!string.IsNullOrEmpty(x.RegexRule)));
            if (!regexExpressions.Any())
            {
                return true;
            }

            bool isRegexSuitable = true;
            foreach (var regexAttr in regexExpressions)
            {
                Regex regex = new Regex(regexAttr.RegexRule);
                isRegexSuitable &= regex.IsMatch(value.ToString());
            }
            return isRegexSuitable;
        }

        public bool ValidateProperty(PropertyInfo prop)
        {
            return ValidateProperty(mValidatedObject, prop);
        }

        public static bool ValidateProperty(Object obj, PropertyInfo prop)
        {
            var attributes = prop.GetCustomAttributes(typeof(ValidatorAttribute),true);
            if (attributes.Length == 0)
            {
                return true;
            }
            var propValue = prop.GetValue(obj,null);
            if(!ValidateRequieredRule(attributes, propValue))
            {
                return false;
            }
            if(!ValidateRangeRule(attributes,propValue))
            {
                return false;
            }
            if (!ValidateRegexRule(attributes, propValue))
            {
                return false;
            }
            return true;
        }


        bool IValidatable.Validate()
        {
            return (GetInvalidPropertiesErrors().Any() == false);
        }
    }
}
