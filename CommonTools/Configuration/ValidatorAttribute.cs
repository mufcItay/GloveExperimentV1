using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTools
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ValidatorAttribute : Attribute
    {
        public bool IsRequiered { get; set; }

        public double  MaxValue { get; set; }

        public double MinValue { get; set; }

        /// <summary>
        /// Regex rule for string validation
        /// </summary>
        public string RegexRule { get; set; }

        public ValidatorAttribute()
        {
            IsRequiered = false;
            MaxValue = double.MaxValue;
            MinValue = double.MinValue;
            RegexRule = string.Empty;
        }
    }
}
