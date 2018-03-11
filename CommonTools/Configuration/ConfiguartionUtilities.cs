using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CommonTools
{
    public static class ConfiguartionUtilities
    {
        public static void SetPropertyGridRowHeight(PropertyGrid pg, int height)
        {
            // get the grid view
            Control view = (Control)pg.GetType().GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(pg);

            // set label width
            FieldInfo fi = view.GetType().GetField("cachedRowHeight", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(view, 25);

            // refresh
            view.Invalidate();
        }

        public static void SetDefaultValues(object obj)
        {
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                var objAttrs = prop.GetCustomAttributes(typeof(ConfigurationPropertyAttribute),true);
                if (objAttrs.Length == 0)
                {
                    continue;
                }
                var attr = objAttrs[0] as ConfigurationPropertyAttribute;
                if (attr == null)
                {
                    continue;
                }
                prop.SetValue(obj, attr.DefaultValue,null);
            }
        }
    }
}
