using System;

namespace SmartDevice
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Device device = new Device(100);
            
            Console.WriteLine(device.Applications.Capacity);
            
        }
    }
}
