using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileClient.Models;
using MobileClient.Services;
using MobileClient.Views;
using System.Collections.ObjectModel;

namespace MobileClient.ViewModels
{
    public partial class StudentListPageViewModel : ObservableObject
    {
        public static List<StudentModel> StudentsListForSearch { get; private set; } = new List<StudentModel>();
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

        private readonly IStudentService _studentService;
        public StudentListPageViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public void GetStudentList() 
        {
            Students.Clear();
            var studentList = _studentService.GetStudentsList();
            if(studentList?.Count > 0)
            {
                studentList = studentList.OrderBy(f => f.FullName).ToList();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
                StudentsListForSearch.Clear();
                StudentsListForSearch.AddRange(studentList);
            }
        }

        [RelayCommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }

        [RelayCommand]
        public async void EditStudent(StudentModel studentModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("StudentDetail", studentModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
        }

        [RelayCommand]
        public void DeleteStudent(StudentModel studentModel)
        {
            var deleteResponse = _studentService.DeleteStudent(studentModel);
            if (deleteResponse > 0)
            {
                GetStudentList();
            }
        }

        [RelayCommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if(response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);

                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
            }
            else if (response == "Delete")
            {
                var deleteResponse = _studentService.DeleteStudent(studentModel);
                if (deleteResponse > 0)
                {
                    GetStudentList();
                }
            }
        }
    }
}
