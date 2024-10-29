using coursemanagment1.Enums;
using coursemanagment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace coursemanagment1.Services
{
    internal class CourseService
    {

        public static List<CourseGroup> Groups = new List<CourseGroup>();
        private int count = 1;

        public void CreateGroup()
        {
            string category;
        bashlangic:
            Console.WriteLine("Category sech\n1.Programming\n2.Design\n3.SystemAdministration");
            category = Console.ReadLine();
            CourseGroup newGroup = new CourseGroup();

            switch (category)
            {
                case "1":
                    newGroup.Category = "Programming";
                    newGroup.No = $"P{count}";
                    count++;
                    break;
                case "2":
                    newGroup.Category = "Design";
                    newGroup.No = $"D{count}";
                    count++;
                    break;
                case "3":
                    newGroup.Category = "SystemAdministration";
                    newGroup.No = $"S{count}";
                    count++;
                    break;
                default:
                    Console.WriteLine("Duzgun deyer daxil edin");
                    goto bashlangic;
            }



        first: Console.WriteLine("Kurs onlinedirmi? (1.Beli, 2.Xeyr)");
            string online = Console.ReadLine();
            switch (online)
            {
                case "1":
                    newGroup.IsOnline = true;
                    newGroup.Limit = 15;
                    break;
                case "2":
                    newGroup.IsOnline = false;
                    newGroup.Limit = 10;
                    break;
                default:
                    Console.WriteLine("Duzgun deyer daxil edin");
                    goto first;
            }

            Groups.Add(newGroup);
            Console.WriteLine("Qrup yaradıldı: " + newGroup.No);
        }

        public void ShowGroups()
        {
            if (Groups.Count == 0)
            {
                Console.WriteLine("qrup yoxdur");
            }
            foreach (CourseGroup group in Groups)
            {
                Console.WriteLine($"Group No: {group.No}, Category: {group.Category}, is online: {group.IsOnline}");
              
            }
            
        }

        public void EditGroup()
        {
        EditGroup:    Console.WriteLine("Deyishiklik etmek istediyiniz qrup nomresini daxil edin:");
            string oldNo = Console.ReadLine();
           
            CourseGroup group = null;

            foreach (var g in Groups)
            {
                if (g.No == oldNo)
                {
                    group = g;
                    break;
                }
            }

            if (group != null)
            {
                Console.WriteLine("Yeni qrup nomresini daxil edin:");
                string newNo = Console.ReadLine();

                bool groupExists = false;
                foreach (var g in Groups)
                {
                    if (g.No == newNo)
                    {
                        groupExists = true;
                        break;
                    }
                }

                if (groupExists)
                {
                    Console.WriteLine("Bu adda qrup artıq movcuddur.");
                    goto EditGroup;
                }
                else
                { 
                    group.No = newNo;
                    Console.WriteLine("Qrup nomresi deyishdirildi.");
                }
            }
            else
            {
                Console.WriteLine("Bele bir qrup yoxdur.");
                goto EditGroup;
            }
        }

        public void ShowGroupStudents()
        {
         ShowAllStudents:   Console.WriteLine("Hansı qrupdakı telebelerin siyahısını gostermek isteyirsiniz? Qrup nomresini daxil edin:");
            string groupNo = Console.ReadLine();
            CourseGroup group = null;

            foreach (var g in Groups)
            {
                if (g.No == groupNo)
                {
                    group = g;

                }
            }


            if (group != null)
            {
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"Ad: {student.Name}, Soyad: {student.Surname}, Group No: {student.GroupNo}, Online: {student.IsOnline}");
                }
            }
            else
            {
                Console.WriteLine("Bele bir qrup yoxdur.");
                goto ShowAllStudents;
            }
        }


        public void ShowAllStudents()
        {

            
            foreach (var group in Groups)
            {
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"Ad: {student.Name}, Soyad: {student.Surname}, Group No: {student.GroupNo}, Online: {student.IsOnline}");
                }
            }
        }

        public void CreateStudent()
        {
           name: Console.WriteLine("Telebenin adını daxil edin:");
            string name = Console.ReadLine().Trim();

            if (Regex.IsMatch(name, @"^[a-zA-Z]{3,25}$"))
            {
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
           
            }
            else
            {
                Console.WriteLine("Ad yalnız herflerden ibaret olmalı ve uzunlugu 3-den az, 25-den çox olmamalıdır.");
                goto name;
            }

                Console.WriteLine("Telebenin soyadını daxil edin:");
           surname: string surname = Console.ReadLine().Trim();
            if (Regex.IsMatch(surname, @"^[a-zA-Z]{3,25}$"))
            {
                surname = char.ToUpper(surname[0]) + surname.Substring(1).ToLower();

            }
            else
            {
                Console.WriteLine("soyad yalnız herflerden ibaret olmalı ve uzunlugu 3-den az, 25-den çox olmamalıdır.");
                goto surname;
                    
            }
          qrupno:  Console.WriteLine("Qrup nomresini daxil edin:");
            string groupNo = Console.ReadLine();
            CourseGroup group = null;

            foreach (var g in Groups)
            {
                if (g.No == groupNo)
                {
                    group = g;
                    break;
                }
                else
                {
                    Console.WriteLine("bele qrup yoxdur");
                    goto qrupno;
                }
            }

            if (group != null && group.Students.Count < group.Limit)
            {
                Student newStudent = new Student
                {
                    Name = name,
                    Surname = surname,
                    GroupNo = groupNo,
                    IsOnline = group.IsOnline
                };

                group.Students.Add(newStudent);

                Console.WriteLine("Telebe yaradıldı.");
            }
            else if (group == null)
            {
                Console.WriteLine("Bele bir qrup yoxdur.");
                goto qrupno;
            }
            else
            {
                Console.WriteLine("Qrupda kifayet qeder yer yoxdur.");
                goto qrupno;
            }

        }
    }
}
