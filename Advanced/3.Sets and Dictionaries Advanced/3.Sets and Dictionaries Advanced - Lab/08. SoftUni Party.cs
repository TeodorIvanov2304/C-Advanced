namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string guests = "";
            //Създавам е хешсети за гости и ВИП гости
            HashSet<string> guestList = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            //Четем гости, докато не получим PARTY
            while ((guests = Console.ReadLine()) != "PARTY")
            {   
                //Създаваме променлива, която пази първия символ на госта
                char firstSymbol = guests[0];
                //Използваме метода char.IsDigit()
                //Ако е цифра, добавяме госта към ВИП, ако не е , към обикновените гости
                if (char.IsDigit(firstSymbol))
                {
                    vip.Add(guests);
                }
                else
                {
                    guestList.Add(guests);
                }
            }

            //Същото, но този път премахваме гостите
            string reservation = "";
            while ((reservation = Console.ReadLine()) != "END")
            {
                char firstSymbol = reservation[0];

                if (char.IsDigit(firstSymbol) && vip.Contains(reservation))
                {
                    vip.Remove(reservation);
                }
                else if(guestList.Contains(reservation))
                {
                    guestList.Remove(reservation);
                }
            }

            //Намираме бр. на хората, които не са дошли
            int didntCome = vip.Count + guestList.Count;
            Console.WriteLine(didntCome);

            //Изпечатваме с foreach, първо ВИП-а
            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}