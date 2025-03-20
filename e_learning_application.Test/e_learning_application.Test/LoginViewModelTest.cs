using Moq;
using e_learning_application.ViewModels;

namespace e_learning_application.Test
{
    public class LoginViewModelTests
    {
        private readonly Mock<MainWindowViewModel> _mockMainWindowViewModel;

        public LoginViewModelTests()
        {
            _mockMainWindowViewModel = new Mock<MainWindowViewModel>();
        }


        // The test verifies if SwitchToStudentView method is called when login method is used.
        // It also verifies that it happens only once.
        [Fact]
        public void Login_ShouldSwitchToStudentView_WhenValidStudentCredentials()
        {
            // Arrange
            var viewModel = new LoginViewModel("Student", _mockMainWindowViewModel.Object);
            viewModel.Username = "student";  // Valid username
            viewModel.Password = "password"; // Valid password

            // Act
            viewModel.Login();

            // Assert
            _mockMainWindowViewModel.Verify(m => m.SwitchToStudentView(), Times.Once); // Verify SwitchToStudentView is called once
            Assert.False(viewModel.IsErrorVisible); // Error message should be hidden
        }
    }
}
