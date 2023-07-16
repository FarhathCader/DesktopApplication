using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Prism.Mvvm;
using Prism.Commands;


 

namespace Desktop01
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<Student> users;

        [ObservableProperty]
        public Student selectedStudent;
        

      





        //To add a student details to the grid
        [RelayCommand]
        public void AddStudent()
        {
            var addUserVM = new AddStudentVM();
            addUserVM.title ="ADD USER";
            AddStudentWindow window = new AddStudentWindow(addUserVM);

            window.ShowDialog();

            if (addUserVM.Student != null)
            {   if (addUserVM.Student.Image == null) addUserVM.Student.Image = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
                Users.Add(addUserVM.Student);
                SelectedStudent = addUserVM.Student;
            }
            
            
            
         
        }

     



        [RelayCommand]
        public void Delete()
        {   
            if(SelectedStudent != null)
            {
                int index = Users.IndexOf(SelectedStudent);
                var message = MessageBox.Show($"Are you sure want to delete {SelectedStudent.FirstName}", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                if (message == MessageBoxResult.Yes)
                {
                    Users.RemoveAt(index);

                    SelectedStudent = Users.FirstOrDefault();
                }
            }
            else if(Users.Count==0) MessageBox.Show("Student list is Empty!!");
            else
            {
                MessageBox.Show("Please Select a Student to Delete");
            }
           
        }


        [RelayCommand]

        public void Edit()
        {
            Student temp = SelectedStudent;
            if (SelectedStudent != null)
            {
            var addUserVM = new AddStudentVM((Student)this.SelectedStudent);
            addUserVM.title = "EDIT USER";
            var window = new AddStudentWindow(addUserVM);

            window.ShowDialog();

            if(SelectedStudent != null)
                {
                    int index = users.IndexOf(SelectedStudent);
                    Users.RemoveAt(index);
                    Users.Insert(index, addUserVM.Student);
                }
           
            }
            else if (Users.Count == 0) MessageBox.Show("Student list is Empty!!");
            else
            {
                MessageBox.Show("Please Select a Student to Delete");
            }
            SelectedStudent = temp;


        }

        public  MainWindowVM()
        {   
            //Create the students collection
            users = new ObservableCollection<Student>();


            
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new Student(12, "Farad", "Cader", "12/1/2000",image1));
            
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new Student(12, "Askar", "Sufiyan", "12/1/2000",image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new Student(12, "Reza", "Fulail", "12/1/2000",image3));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new Student(12, "SHfa", "Kareem", "12/1/2000", image4));
            users.Add(new Student(12, "Farad", "Cader", "12/1/2000", image1));
            users.Add(new Student(12, "Askar", "Sufiyan", "12/1/2000", image2));
            users.Add(new Student(12, "Reza", "Fulail", "12/1/2000", image3)); users.Add(new Student(12, "SHfa", "Kareem", "12/1/2000", image4));
            users.Add(new Student(12, "Farad", "Cader", "12/1/2000", image1));
            users.Add(new Student(12, "Askar", "Sufiyan", "12/1/2000", image2));
            users.Add(new Student(12, "Reza", "Fulail", "12/1/2000", image3)); users.Add(new Student(12, "SHfa", "Kareem", "12/1/2000", image4));
            users.Add(new Student(12, "Farad", "Cader", "12/1/2000", image1));
            users.Add(new Student(12, "Askar", "Sufiyan", "12/1/2000", image2));
            users.Add(new Student(12, "Reza", "Fulail", "12/1/2000", image3)); users.Add(new Student(12, "SHfa", "Kareem", "12/1/2000", image4));
            users.Add(new Student(12, "Farad", "Cader", "12/1/2000", image1));
            users.Add(new Student(12, "Askar", "Sufiyan", "12/1/2000", image2));
            users.Add(new Student(12, "Reza", "Fulail", "12/1/2000", image3)); users.Add(new Student(12, "SHfa", "Kareem", "12/1/2000", image4));
            users.Add(new Student(12, "Farad", "Cader", "12/1/2000", image1));
            users.Add(new Student(12, "Askar", "Sufiyan", "12/1/2000", image2));
            users.Add(new Student(12, "Reza", "Fulail", "12/1/2000", image3)); users.Add(new Student(12, "SHfa", "Kareem", "12/1/2000", image4));
            users.Add(new Student(12, "Farad", "Cader", "12/1/2000", image1));
            users.Add(new Student(12, "Askar", "Sufiyan", "12/1/2000", image2));
            users.Add(new Student(12, "Reza", "Fulail", "12/1/2000", image3));
            selectedStudent = users[0];
            
            
           








        }
    }
}

