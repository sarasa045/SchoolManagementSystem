using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using SchoolApp.Commands;

namespace StudentApp.ViewModels
{
    public class StudentDetailsViewModel : INotifyPropertyChanged
    {
        /*private string firstName;
        private string lastName;
        private string age;
        private string className;
        private string section;
        private string fatherName;
        private string motherName;

        public string FirstName
        {
            get => firstName;
            set { firstName = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get => lastName;
            set { lastName = value; OnPropertyChanged(); }
        }

        public string Age
        {
            get => age;
            set { age = value; OnPropertyChanged(); }
        }

        public string ClassName
        {
            get => className;
            set { className = value; OnPropertyChanged(); }
        }

        public string Section
        {
            get => section;
            set { section = value; OnPropertyChanged(); }
        }

        public string FatherName
        {
            get => fatherName;
            set { fatherName = value; OnPropertyChanged(); }
        }

        public string MotherName
        {
            get => motherName;
            set { motherName = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public ICommand ClearCommand { get; }

        public StudentDetailsViewModel()
        {
            SaveCommand = new RelayCommand(SaveStudent);
            ClearCommand = new RelayCommand(ClearFields);
        }

        private void SaveStudent()
        {
            MessageBox.Show("Student details saved successfully");
        }

        private void ClearFields()
        {
            FirstName = "";
            LastName = "";
            Age = "";
            ClassName = "";
            Section = "";
            FatherName = "";
            MotherName = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
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

        public StudentDetailsViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            ClearCommand = new RelayCommand(Clear);
        }

        private void Save(object obj)
        {
            // Business Logic (for now just demo)
            string message = $"Student: {FirstName} {LastName}, Age: {Age}";
            System.Windows.MessageBox.Show(message);
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