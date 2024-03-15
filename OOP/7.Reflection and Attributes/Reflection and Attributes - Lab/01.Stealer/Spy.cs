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
    }
}
