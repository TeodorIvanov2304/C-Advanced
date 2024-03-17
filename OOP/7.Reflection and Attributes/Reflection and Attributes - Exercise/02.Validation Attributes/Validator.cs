using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {   
            //Взимаме типа на обекта
            Type type = obj.GetType();

            //Взимаме пропъртитата на type
            PropertyInfo[] properties = type.GetProperties();

            //Филтрираме само пропъртитата, които имат custom attribute. С инхерит взимаме и децата на класа 
            PropertyInfo[] propertiesWithCustomAttributes = properties.Where(p=> Attribute.IsDefined(p,typeof(MyValidationAttribute),inherit:true)).ToArray();
            
            foreach(PropertyInfo property in propertiesWithCustomAttributes)
            {
                var validationAttributes = property.GetCustomAttributes(typeof(MyValidationAttribute), inherit:true)
                    .Cast<MyValidationAttribute>();

                foreach (var attribute in validationAttributes)
                {
                    object value = property.GetValue(obj);

                    if (attribute.IsValid(value) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
