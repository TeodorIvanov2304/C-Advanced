namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tests
    {
        private Device device;
        private int MemoryCapacity = 100;
        private int AvailableMemory = 100;
        private int Photos = 0;
        private List<string> Applications;

        [SetUp]
        public void Setup()
        {
            device = new Device(MemoryCapacity);
            
        }

        //Конструктор - 10 т, последен ред Assert.That(device.Photos, Is.EqualTo(0));
        // }
        [Test] 
        public void Ctor_Initializing_RunsCorrectly()
        {
            Assert.That(device, Is.Not.Null);
            Assert.That(device.Applications, Is.Not.Null);
            Assert.That(device.MemoryCapacity, Is.EqualTo(MemoryCapacity));
            Assert.That(device.AvailableMemory, Is.EqualTo(MemoryCapacity));
            Assert.That(device.Photos, Is.EqualTo(0));
        }

        //40/100 за TakePhoto + Ctor
        [Test]
        public void TakePhoto_ReturnsTrue_WhenMemoryIsLargerThanPhotoSize()
        {
            bool isPhoto = device.TakePhoto(1) == true;
            Assert.That(device.AvailableMemory, Is.EqualTo(99));
            Assert.That(device.Photos,Is.EqualTo(1));
            Assert.That(device.TakePhoto(1),Is.EqualTo(isPhoto));
            
        }
        
        [Test]
        public void TakePhoto_ReturnsFalse_WhenMemoryIsSmallerThanPhotoSize()
        {
            bool isPhoto = device.TakePhoto(101) == false;
            Assert.That(device.TakePhoto(101), Is.EqualTo(false));
            Assert.That(device.AvailableMemory, Is.EqualTo(100));
            Assert.That(device.Photos, Is.EqualTo(0));

        }

        //80/100 след завършен InstallApp
        [TestCase("Telegram",1)]
        public void InstallApp_WorkingCorrectly(string appName, int appSize)
        {
            device.InstallApp(appName, appSize);
            string expectedString = $"{appName} is installed successfully. Run application?";

            Assert.That(device.AvailableMemory, Is.EqualTo(99));
            Assert.That(device.Applications.Count,Is.EqualTo(1));
            Assert.That(device.InstallApp(appName, appSize), Is.EqualTo(expectedString));
        }

        [TestCase("Telegram", 101)]
        [TestCase("Telegram", 101111)]
        public void InstallApp_NotEnoughMemory(string appName, int appSize)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                device.InstallApp(appName, appSize);
            });

            Assert.That(ex.Message,Is.EqualTo("Not enough available memory to install the app."));
        }

        [Test]
        public void FormatDevice_IsWorkingCorrectly()
        {
            
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyApp", 500);

            device.FormatDevice();

            Assert.That(memoryCapacity, Is.EqualTo(device.AvailableMemory));
            Assert.That(device.Photos, Is.EqualTo(0));
            Assert.That(device.Applications.Count, Is.EqualTo(0));
        }

        //90/100 за GetDeviceStatus
        [Test]
        public void GetDeviceStatus_ReturnsTheCorrectString()
        {
            device.InstallApp("Game", 2);
            device.InstallApp("SA", 2);
            device.TakePhoto(1);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: {device.MemoryCapacity} MB, Available Memory: {device.AvailableMemory} MB");
            stringBuilder.AppendLine($"Photos Count: {device.Photos}");
            stringBuilder.AppendLine($"Applications Installed: {string.Join(", ", device.Applications)}");

            string expectedResult = stringBuilder.ToString().TrimEnd();
            string actualResult = device.GetDeviceStatus();
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}