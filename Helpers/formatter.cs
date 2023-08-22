using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class FreqCustomFormatter : IFormatProvider, ICustomFormatter
    {
        // implementing the GetFormat method of the IFormatProvider interface 
        public object GetFormat(System.Type type)
        {
            return this;
        }
        // implementing the Format method of the ICustomFormatter interface 
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // implement formatting logic here - this method must return the formatted string 
            // format and args parameters specify the format string and the original value respectively 
            // ... 
            return HelperFunctions.getHZ(Convert.ToDouble(arg));
        }
    }

    public class FreqCustomFormatterHZ : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type type)
        {
            return (object)this;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return HelperFunctions.getHZ(Convert.ToDouble(arg) / 1000.0);
        }
    }
}
