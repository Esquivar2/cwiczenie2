using LegacyApp;
using Xunit.Sdk;

namespace LegacyAppTests
{
    public class UserServiceTests
    {
        [Fact]
        public void AddUser_Should_Return_False_When_Missing_FirstName()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result
                = service.AddUser(null, null, "email@gmail.com", new DateTime(1900, 1, 1), 1);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result = service.AddUser("Jan", "Kowalski", "mail_test", new DateTime(1900,01,01) , 1);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Age_Less_Than_21()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result = service.AddUser("Jan", "Kowalski", "email@gmail.com", new DateTime(2024, 01, 01), 1);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Normal_Client_With_Credit_Limit_Less_Than_500()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result = service.AddUser("Jan", "Kowalski", "email@gmail.com", new DateTime(1900, 01, 01), 1);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_Should_Return_True_When_Client_Type_Is_VeryImportantClient()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result = service.AddUser("Jan", "Malewski", "malewski@gmail.pl", new DateTime(1900, 01, 01), 2);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddUser_Should_Return_True_When_Client_Type_Is_ImportantClient()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result = service.AddUser("Jan", "Smith", "smith@gmail.pl", new DateTime(1900, 01, 01), 3);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddUser_Should_Return_True_When_Client_Type_Is_NormalClient()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result = service.AddUser("Jan", "Kwiatkowski", "kwiatkowski@wp.pl", new DateTime(1900, 01, 01), 5);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddUser_Should_Throw_ArgumentException_When_ClientId_Not_Exists()
        {
            //Arrange
            var service = new UserService();

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
                service.AddUser("John", "Smith", "kowalski@wp.pl", new DateTime(1998, 12, 9), 666));
        }

        [Fact]
        public void AddUser_Should_Throw_ArgumentException_When_CreditLimit_Not_Exists_For_User()
        {
            //Arrange
            var service = new UserService();

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
                service.AddUser("John", "Test", "kowalski@wp.pl", new DateTime(1998, 12, 9), 1));
        }

    }
}