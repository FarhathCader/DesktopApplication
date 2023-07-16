using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public partial class AddStudentVM : ObservableObject

    {
        
   
        [ObservableProperty]
        public string firstname;


        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public DateTime dob;


        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;



        public Student temp;


        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;

        [ObservableProperty]
        public string selectedImagePath;

        public Student Student { get; private set; }
        public Action CloseAction { get; internal set; }



        public AddStudentVM(Student u)
        {
            Student = u;
            temp = u;
            firstname  = Student.FirstName;
            lastname = Student.LastName;
            age = Student.Age;
            gpa = Student.GPA;
            dateofbirth = Student.DateOfBirth;
           
            selectedImage=Student.Image;
            selectedImagePath = Student.ImagePath;
            
           
            
            
        }
        public AddStudentVM()
        {
            Age = 0;
            Dateofbirth = "01/01/2000";
            Gpa = 0;
            




        }


        


   


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                SelectedImage = new BitmapImage(new Uri(dialog.FileName));
               
                
                MessageBox.Show("Image Uploaded succesfully");
            }

            SelectedImagePath = selectedImage.ToString();
            
        }


      



     
        [RelayCommand]
        public void Save()
        {
           
            
            if(Student==null)
            {

                Student = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    DateOfBirth = dob.Date.ToShortDateString(),
                    Image = selectedImage,
                    ImagePath = selectedImagePath,
                    GPA = gpa

                };


            }
            else
            {
                
                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.Age = age;
                Student.GPA = gpa;
                Student.Image = selectedImage;
                Student.DateOfBirth = dob.Date.ToShortDateString();
                Student.ImagePath = selectedImagePath;
                
                
                
            }
            if(Student.FirstName == null )MessageBox.Show("First Name cannot be Empty ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if(Student.LastName == null) MessageBox.Show("Last Name cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if(Student.Age<=0) MessageBox.Show("Invalid input for age", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.DateOfBirth == null) MessageBox.Show("Please enter the Date of Birth", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.GPA<0 || Student.GPA>4) MessageBox.Show("GPA should be in between 0 to 4", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if(Student.Image==null) MessageBox.Show("Upload a Photo!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                
                CloseAction();
            }




            Application.Current.MainWindow.Show();


        }

        private DelegateCommand cancelCommand;
        public ICommand CancelCommand => cancelCommand ??= new DelegateCommand(Cancel);

        private void Cancel()
        {
            var vm = MessageBox.Show("Are you sure want to cancel", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (vm == MessageBoxResult.Yes)
            {
                Student = temp;
                CloseAction();
                Application.Current.MainWindow.Show();
            }


        }

    }
}
