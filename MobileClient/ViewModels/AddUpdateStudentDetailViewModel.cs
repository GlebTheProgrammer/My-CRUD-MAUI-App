using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MobileClient.Models;
using MobileClient.Services;

namespace MobileClient.ViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();
        private readonly IStudentService _studentService;

        public AddUpdateStudentDetailViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public async void AddUpdateStudent()
        {
            int response = -1;
            if (StudentDetail.Id > 0)
            {
                response = _studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                response = _studentService.AddStudent(new Models.StudentModel
                {
                    FirstName = StudentDetail.FirstName,
                    LastName = StudentDetail.LastName,
                    Email = StudentDetail.Email
                });
            }

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student info saved", "Record saved successfully", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not Added", "Something went wrong while adding record", "OK");
            }
        }
    }
}
