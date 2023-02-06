using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using AGVDispatcher.Entity;
using System.Reflection;
using System.Windows.Forms;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit { }
}


namespace AGVDispatcher.Util
{
    public static class MyExtentions
    {
        static MethodInfo list_refreshitem_method;
        static MyExtentions()
        {
            list_refreshitem_method = typeof(ListBox).GetMethod("RefreshItem", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Enum is null!");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])
             fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
           
            return description;
        }

        public static System.Drawing.Color? GetUIColor(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Enum is null!");
            }

            System.Drawing.Color? rt = null;
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            UIColorAttribute[] attributes =
               (UIColorAttribute[])
             fieldInfo.GetCustomAttributes(typeof(UIColorAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                rt = attributes[0].@Color;
            }
 
            return rt;
        }

        public static void RefreshItemEx(this ListBox box, int index)
        {
            list_refreshitem_method.Invoke(box, new object[] { index });
        }
    }
    
}

