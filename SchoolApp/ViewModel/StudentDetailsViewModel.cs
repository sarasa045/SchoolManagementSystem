using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace StudentApp.ViewModels
{
    public class StudentDetailsViewModel : INotifyPropertyChanged
    {
        private string firstName;
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
        }
    }
}