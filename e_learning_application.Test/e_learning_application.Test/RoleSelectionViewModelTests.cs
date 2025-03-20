using Xunit;
using Moq;
using e_learning_application.ViewModels;

namespace e_learning_application.Tests
{
    public class RoleSelectionViewModelTests
    {
        private readonly Mock<MainWindowViewModel> _mainWindowViewModelMock;
        private readonly RoleSelectionViewModel _roleSelectionViewModel;

        public RoleSelectionViewModelTests()
        {
            _mainWindowViewModelMock = new Mock<MainWindowViewModel>();
            _roleSelectionViewModel = new RoleSelectionViewModel(_mainWindowViewModelMock.Object);
        }

        [Fact]
        public void SelectStudent_ShouldSwitchToStudentLoginView()
        {
            // Act
            _roleSelectionViewModel.SelectStudentCommand.Execute(null);

            // Assert
            _mainWindowViewModelMock.Verify(m => m.SwitchToLoginView("Student"), Times.Once);
        }

        [Fact]
        public void SelectTeacher_ShouldSwitchToTeacherLoginView()
        {
            // Act
            _roleSelectionViewModel.SelectTeacherCommand.Execute(null);

            // Assert
            _mainWindowViewModelMock.Verify(m => m.SwitchToLoginView("Teacher"), Times.Once);
        }
    }
}