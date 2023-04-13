using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueCollectionAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            return ((List<Item>)value).Distinct().Count() == ((List<Item>)value).Count;
        }
    }
}
