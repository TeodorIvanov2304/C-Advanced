namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice TVDevice;
        private const string Brand = "LG";
        private const double Price = 1999;
        private const int ScreenWidth = 60;
        private const int ScreenHeight = 60;


        [SetUp] 
        public void Setup()
        {
            TVDevice = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeight);
        }

        [Test]
        public void Ctor_InitializesObject_PropertiesAreCorrect()
        {
            Assert.That(TVDevice, Is.Not.Null);
            Assert.That(TVDevice.Brand, Is.EqualTo(Brand));
            Assert.That(TVDevice.Price, Is.EqualTo(Price));
            Assert.That(TVDevice.ScreenWidth, Is.EqualTo(ScreenWidth));
            Assert.That(TVDevice.ScreenHeigth, Is.EqualTo(ScreenHeight));
            //Преписваме стойностите , които очакваме от private fields lastChannel, lastVolume, lastMuted
            Assert.That(TVDevice.CurrentChannel, Is.EqualTo(0));
            Assert.That(TVDevice.Volume, Is.EqualTo(13));
            Assert.That(TVDevice.IsMuted, Is.EqualTo(false));


        }
        [Test]
        public void ToString_Returns_CorrectString()
        {
            string expectedString =
                $"TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeight}, Price {Price}$";
            string actualString = TVDevice.ToString();
            Assert.That(expectedString, Is.EqualTo(actualString));
        }

        [Test]
        public void SwitchOn_SwitchesTheTVOn()
        {   
            //Заместваме имената на промоменливите в {} с очакваните от fields
            string expected = $"Cahnnel 0 - Volume 13 - Sound On";
            //Викаме метода, за да напълним actual
            string actual = TVDevice.SwitchOn();

            Assert.That(expected,Is.EqualTo(actual));
        }

        [Test]
        public void ChangeChannel_SetsTheRightChannel()
        {
            int expectedChannel = 7;
            int actualChannel = TVDevice.ChangeChannel(7);
            Assert.That(expectedChannel,Is.EqualTo(actualChannel));
        }

        [Test]
        public void ChangeChannel_WhenChannelIsNegativeThrowException()
        {
            int channel = -7;
            ;
            
            
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                TVDevice.ChangeChannel(channel);
            });

            Assert.That(ex.Message, Is.EqualTo("Invalid key!"));
        }

        [Test]
        public void Mute_Toggles_TheMute()
        {   
            //Изпробваме първия вариант : isMuted = true
            TVDevice.MuteDevice();
            Assert.That(TVDevice.IsMuted,Is.EqualTo(true));

            //Втори вариант : isMuted = false
            TVDevice.MuteDevice();
            Assert.That(TVDevice.IsMuted, Is.EqualTo(false));

        }

        //Подаваме и двете стойности, които ще се тестват една след друга
        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeUp_Sets_Correct_Volume(int volumeChange)
        {
            string expected = "Volume: 20";
            string actual = TVDevice.VolumeChange("UP",volumeChange);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void VolumeUp_WhenVolumeIsMoreThan100_SetsVolumeTo100()
        {
            string expected = "Volume: 100";
            string actual = TVDevice.VolumeChange("UP", 100);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeDown_Sets_Correct_Volume(int volumeChange)
        {
            string expected = "Volume: 6";
            string actual = TVDevice.VolumeChange("DOWN", volumeChange);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void VolumeDown_WhenVolumeIsLessThan0_SetsVolumeTo0()
        {
            string expected = "Volume: 0";
            string actual = TVDevice.VolumeChange("DOWN", -100);
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}