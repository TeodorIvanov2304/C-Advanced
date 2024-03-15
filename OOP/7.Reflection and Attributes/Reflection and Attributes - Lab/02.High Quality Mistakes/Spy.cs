using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {   
            //Взимаме типа на класа, който ще разследваме
            Type typeClass = Type.GetType(investigatedClass);

            //Правим масив от тип FieldInfo и използваме метода GetFields, и енумерацията BindingFlags за да вземем fields от класа Hacker. В случая Instance,Public,NonPublic members of the class
            FieldInfo[] classFields = typeClass.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            //Алтернативно изписване
            //FieldInfo[] classFields = typeClass.GetFields((BindingFlags)60);
            StringBuilder sb = new StringBuilder();

            //Създаваме обект от подадения клас, чрез класа Activator и метода CreateInstance
            Object classInstance = Activator.CreateInstance(typeClass, new object[] { });

            
            sb.AppendLine($"Class under investigation: {investigatedClass}");

            //Всички филдове в колекцията classFields, които съдържа името на част от подадените полета
            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                //Добавяме към StringBuilder
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = className.GetType();

            //Взимаме всички филдове
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            //Взимаме всички публични методи
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            //Взимаме всички private методи
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new();
            
            //За всяко поле
            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            //Намираме всички гетъри, с израза Where(m => m.Name.StartsWith("get")
            foreach (MethodInfo publicMethod in publicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{publicMethod.Name} have to be public!");
            }

            foreach (MethodInfo privateMethod in privateMethods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{privateMethod.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
    }
}
