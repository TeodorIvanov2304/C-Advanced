namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2);
        }

        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            //Arrange
            int expectedResult = 2;


            //Act
            //Database database = new Database(1, 2);
            int actualResult = database.Count;

            //Assert
            //�����������, ���� ������ ����� ��� ��������� ���� ��������
            Assert.IsTrue(database.Count == expectedResult);
            //����������� ���� ������ ����� �� � ������
            Assert.NotNull(database);
            //�� �������� ������� �� � ������������ �� �������
            //Assert.AreEqual(expectedResult, actualResult);
        }

        //� �������� TestCase ����� �� ���������� ��������� (actual result)
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void CreateDatabaseShouldAddElementCorrectly(int[] data)
        {
            //Act
            database = new(data);
            int[] actualResult = database.Fetch();

            //Assert
            Assert.AreEqual(data, actualResult);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]

        public void CreateDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            //Act

            //�������, ���� �������� ������ ������
            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            database = new Database(data));

            //�������, ���� �������� � ������, ����� ��������
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]

        public void DataBaseCountShouldWorkCorrectly()
        {
            int expectedResult = 2;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        //�������� ���� ������ ��������, ���� �������� -3 � 0, �� ����� ���������� ������
        [TestCase(-3)]
        [TestCase(0)]

        public void DatabaseAddMethodShouldIncreaseCount(int element)
        {
            int expectedResult = 3;
            database.Add(element);
            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void DatabaseAddMethodShouldAddElementCorrectly(int[] data)
        {
            database = new Database ();

            foreach (int number in data)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [Test]
        
        public void DatabaseAddMethodShouldThrowExceptionWhenCountIsMoreThan16()
        {
            for (int i = 0; i < 14; i++)
            {
                database.Add(i);
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(1);
            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }

        [Test]

        public void DatabaseRemoveMethodShouldDecreaseCount()
        {
            int expectedResult = 1;

            database.Remove();
            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]

        public void DatabaseRemoveMethodShouldRemoveElementCorrectly()
        {   
            //Arrange
            //������ ����� �� ���!!!
            int[] expectedResult = Array.Empty<int>();

            //Act
            database.Remove();
            database.Remove();

            //Assert
            Assert.AreEqual(expectedResult, database.Fetch());
        }

        [Test]
        //InvalidOperationException("The collection is empty!");
        public void DatabaseRemoveMethodShouldThrowExceptionWhenEmpty()
        {
            database = new Database ();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

            Assert.AreEqual("The collection is empty!", ex.Message);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void DatabaseFetchMethodShouldReturnElementCorrectly(int[] data)
        {
            database = new Database(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }
    }
}
