using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class ListSizeAttribute : ValidationAttribute
    {
        public int Size { get; set; }

        public override bool IsValid(object? value)
        {
            if (value == null || value is not List<Item>)
            {
                return false;
            }

            if (((List<Item>)value).Count > Size)
            {
                return false;
            }

            return true;
        }

    }
}
