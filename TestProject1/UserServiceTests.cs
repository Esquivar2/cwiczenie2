using LegacyApp;

namespace TestProject1
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
        public void AddUser_Should_Return_False_When_Email_Dont_Have_At_Sign()
        {
            //Arrange
            var service = new UserService();
            //Act
            var result
                = service.AddUser("Jan", "Kowalski", "emailAtgmail.com", new DateTime(1900, 1, 1), 1);
            //Assert
            Assert.False(result);
        }
    }
}

//walidacja maila, wieku
// _ = ... <- nie uzywam tej zmiennej
// regularne testy - ciagle uzywac testow