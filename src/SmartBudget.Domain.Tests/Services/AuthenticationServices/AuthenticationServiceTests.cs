using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using SmartBudget.Domain.Exceptions;
using SmartBudget.Domain.Models;
using SmartBudget.Domain.Services;
using SmartBudget.Domain.Services.AuthenticationServices;

using System.Threading.Tasks;

namespace SmartBudget.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IUserService> _mockUserService;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void Setup()
        {
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _mockUserService = new Mock<IUserService>();
            _authenticationService = new AuthenticationService(_mockUserService.Object, _mockPasswordHasher.Object);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUsername_ReturnsUserForCorrectUsername()
        {
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockUserService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Models.User() { Username = expectedUsername });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            User user = await _authenticationService.Login(expectedUsername, password);

            string actualUsername = user.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public void Login_WithIncorrectPasswordForExistingUsername_ThrowInvalidPasswordExceptionForUsername()
        {
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockUserService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new User() { Username = expectedUsername });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            InvalidPasswordException exception = Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationService.Login(expectedUsername, password));

            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public void Login_WithNonExistingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            UserNotFoundException exception = Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationService.Login(expectedUsername, password));

            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            string password = "testpassword";
            string confirmPassword = "confirmtestpassword";
            RegistrationResult expected = RegistrationResult.PasswordsDoNotMatch;

            RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            string email = "test@gmail.com";
            _mockUserService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new User());
            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            RegistrationResult actual = await _authenticationService.Register(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {
            string username = "testuser";
            _mockUserService.Setup(s => s.GetByUsername(username)).ReturnsAsync(new User());
            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), username, It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithNonExistingUserAndMatchingPasswords_ReturnsSuccess()
        {
            RegistrationResult expected = RegistrationResult.Success;

            RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }
    }
}