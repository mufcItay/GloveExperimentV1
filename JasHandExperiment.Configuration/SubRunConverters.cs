using System;
using System.ComponentModel; 

namespace JasHandExperiment.Configuration
{
    // This is a special type converter which will be associated with the SubRunConfiguration class.
    // It converts an SubRunConfiguration object to string representation for use in a property grid.
    internal class SubRunConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType )
		{
			if( destType == typeof(string) && value is SubRunConfiguration)
			{
                // Cast the value to an Employee type
                SubRunConfiguration subRun = (SubRunConfiguration)value;

				// Return department and department role separated by comma.
				return "Blocks Amount: "+ subRun.BlocksAmount + ", Inter Block Tiemout: " + subRun.InterBlockTimeout;
            }
			return base.ConvertTo(context,culture,value,destType);
		}
	}

    // This is a special type converter which will be associated with the SubRunCollection class.
    // It converts an SubRunCollection object to a string representation for use in a property grid.
    internal class SubRunCollectionConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType )
		{
			if( destType == typeof(string) && value is SubRunCollection )
			{
				// Return department and department role separated by comma.
				return "Collection of sub-runs";
			}
			return base.ConvertTo(context,culture,value,destType);
		}
	}

}
