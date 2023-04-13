using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class ParticipantNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || value is not string)
            {
                return false;
            }

            string strValue = value as string;

            if (string.IsNullOrWhiteSpace(strValue))
            {
                return false;
            }

            if (strValue.Length > 10)
            {
                return false;
            }

            if (!strValue.All(char.IsLetterOrDigit))
            {
                return false;
            }

            return true;
        }
    }
}
