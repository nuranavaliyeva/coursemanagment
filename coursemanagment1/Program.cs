using coursemanagment1.Services;
using System.Xml.Serialization;

namespace coursemanagment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                CourseService courseService = new CourseService();
                string choice;
                do
                {
                    Console.WriteLine("Secim edin:\n1. Yeni qrup yarat\n2. Qrupların siyahısını goster\n3. Qrup uzerinde duzelish etmek\n4. Qrupdakı telebelerin siyahısını goster\n5. Butun telebelerin siyahısını goster\n6. Telebe yarat\n\n\n0. Exit");
                     choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            courseService.CreateGroup();
                            break;
                        case "2":
                            courseService.ShowGroups();
                            break;
                        case "3":
                            courseService.EditGroup();
                            break;
                        case "4":
                            courseService.ShowGroupStudents();
                            break;
                        case "5":
                            courseService.ShowAllStudents();
                            break;
                        case "6":
                            courseService.CreateStudent();
                            break;
                      
                        
                    }

                }
                while (choice != "0");
            }

        }
    }
}

    




