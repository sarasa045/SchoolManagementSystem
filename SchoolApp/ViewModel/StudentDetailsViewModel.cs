using SchoolApp.Commands;
using SchoolApp.Data;
using SchoolApp.Model;
using SchoolApp.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using System.Windows.Input;

namespace SchoolApp.ViewModel
{
    public class StudentDetailsViewModel : INotifyPropertyChanged
    {

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(nameof(Age)); }
        }

        private string _class;
        public string Class
        {
            get => _class;
            set { _class = value; OnPropertyChanged(nameof(Class)); }
        }

        private string _section;
        public string Section
        {
            get => _section;
            set { _section = value; OnPropertyChanged(nameof(Section)); }
        }

        private string _fatherName;
        public string FatherName
        {
            get => _fatherName;
            set { _fatherName = value; OnPropertyChanged(nameof(FatherName)); }
        }

        private string _motherName;
        public string MotherName
        {
            get => _motherName;
            set { _motherName = value; OnPropertyChanged(nameof(MotherName)); }
        }


        public ICommand SaveCommand { get; }
        public ICommand ClearCommand { get; }

        private readonly StudentRepository _repo;
        public StudentDetailsViewModel()
        {
            _repo = new StudentRepository();
            SaveCommand = new RelayCommand(Save, CanSave);
            ClearCommand = new RelayCommand(Clear);
        }
        private bool CanSave(object obj)
        {
            // simple validation: require first and last name
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
        }

        private void Save(object obj)
        {
            var student = new Students
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Class = Class,
                Section = Section,
                FatherName = FatherName,
                MotherName = MotherName
            };

            try
            {
                var id = _repo.InsertStudent(student);
                if (id > 0)
                {
                    MessageBox.Show("Student saved (Id: " + id + ")", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    Clear(null);
                }
                else
                {
                    MessageBox.Show("Student was not saved.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear(object obj)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Age = 0;
            Class = string.Empty;
            Section = string.Empty;
            FatherName = string.Empty;
            MotherName = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
}