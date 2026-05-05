using System.Collections.ObjectModel;
using SchoolApp.Model;
using SchoolApp.Data;

namespace SchoolApp.ViewModel
{
    public class StudentsViewModel
    {
        private readonly StudentRepository _repo;

        public ObservableCollection<Students> Students { get; }
        

        public StudentsViewModel()
        {
            _repo = new StudentRepository();
            Students = new ObservableCollection<Students>();
        }

        public void LoadAll()
        {
            Students.Clear();
            var list = _repo.GetAllStudents();
            foreach (var s in list)
                Students.Add(s);
        }

        public int InsertStudent(Students student)
        {
            var id = _repo.InsertStudent(student);
            if (id > 0)
            {
                student.Id = id;
                Students.Add(student);
            }
            return id;
        }

        public bool UpdateStudent(Students student)
        {
            var ok = _repo.UpdateStudent(student);
            if (ok)
            {
                // optionally refresh list or update item in ObservableCollection
            }
            return ok;
        }

        public bool DeleteStudent(int id)
        {
            var ok = _repo.DeleteStudent(id);
            if (ok)
            {
                var existing = System.Linq.Enumerable.FirstOrDefault(Students, s => s.Id == id);
                if (existing != null) Students.Remove(existing);
            }
            return ok;
        }
    }
}