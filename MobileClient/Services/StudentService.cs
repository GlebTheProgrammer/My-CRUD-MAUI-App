using MobileClient.Models;
using SQLite;
using System.Text.Json;

namespace MobileClient.Services
{
    public class StudentService : IStudentService
    {
        //private SQLiteAsyncConnection _dbConnection;
        private List<StudentModel> students;

        public StudentService()
        {
            SetUpDb();
        }

        //private async void SetUpDb()
        //{
        //    if (_dbConnection is null)
        //    {
        //        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
        //        _dbConnection = new SQLiteAsyncConnection(dbPath);
        //        await _dbConnection.CreateTableAsync<StudentModel>();
        //    }
        //}

        private void SetUpDb()
        {
            //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Students.json");
            //using FileStream createStream = File.Create(fileName);
            //await JsonSerializer.SerializeAsync(createStream, students);
            //await createStream.DisposeAsync();

            //string fileName = "Students.json";
            //using FileStream openStream = File.OpenRead(fileName);
            //List<StudentModel> st =
            //    await JsonSerializer.DeserializeAsync<List<StudentModel>>(openStream);

            //students = st;
            students = new List<StudentModel>();
        }

        public int AddStudent(StudentModel student)
        {
            //using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Students.json"), FileMode.OpenOrCreate))
            //{
            //    if (students.Count > 0)
            //        student.Id = students.MaxBy(x => x.Id).Id;
            //    else
            //        student.Id = 0;

            //    students.Add(student);
            //    await JsonSerializer.SerializeAsync<List<StudentModel>>(fs, students);
            //    return 1;
            //}

            if (students.Count > 0)
                student.Id = students.MaxBy(x => x.Id).Id + 1;
            else
                student.Id = 1;

            students.Add(student);
            return 1;

            //return await _dbConnection.InsertAsync(student);
        }

        public int DeleteStudent(StudentModel student)
        {
            //using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Students.json"), FileMode.OpenOrCreate))
            //{
            //    students.Remove(student);
            //    await JsonSerializer.SerializeAsync<List<StudentModel>>(fs, students);
            //    return 1;
            //}

            students.Remove(student);
            return 1;

            //return await _dbConnection.DeleteAsync(student);
        }

        public List<StudentModel> GetStudentsList()
        {
            return students;
        }

        public int UpdateStudent(StudentModel student)
        {
            //using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Students.json"), FileMode.OpenOrCreate))
            //{
            //    var prevStudent = students.Find(st => st.Id == student.Id);
            //    prevStudent = student;

            //    await JsonSerializer.SerializeAsync<List<StudentModel>>(fs, students);
            //    return 1;
            //}

            var prevStudent = students.Find(st => st.Id == student.Id);
            students[students.IndexOf(prevStudent)] = student;
            return 1;
        }
    }
}
