﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Desktop01.Model
{
    public class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

     
        public BitmapImage Image { get; set; }  

        public string  DateOfBirth{ get; set; }
        public double GPA { get; set; }
        public string ImagePath { get; set; }



        public Student(int age, string firstName, string lastName, string dateOfBirth,BitmapImage  image )
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = image;
            ImagePath = image.ToString();
            
            

        }
      
        public Student()
        {
            
        }
    }
    
}
