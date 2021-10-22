using System;
using EntityFrameworkDemo.Models;
using System.Linq;
namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string ch = "y";
            while (ch == "y")
            {
                Console.WriteLine("Enter Choice");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. List");
                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToByte(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Record");
                            Console.WriteLine("Enter Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Batch");
                            string batch = Console.ReadLine();
                            Console.WriteLine("Enter Marks");
                            int marks = Convert.ToByte(Console.ReadLine());
                            Student student = new Student()
                            {
                                Name = name,
                                Batch = batch,
                                Marks = marks
                            };
                            InsertRecords(student);
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Id whose Record to Search");
                            int id = Convert.ToByte(Console.ReadLine());
                            Console.WriteLine("Enter Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Batch");
                            string batch = Console.ReadLine();
                            Console.WriteLine("Enter Marks");
                            int marks = Convert.ToByte(Console.ReadLine());
                            Student student = new Student()
                            {
                                Name = name,
                                Batch = batch,
                                Marks = marks
                            };
                            Update(id, student);
                            break; 
                        }
                    case 3: {
                            Console.WriteLine("Enter Id whose Record to Search");
                            int id = Convert.ToByte(Console.ReadLine());
                            Delete(id);
                            break;
                    case 4:
                        {
                            Console.WriteLine("Enter Id whose Record to Search");
                            int id = Convert.ToByte(Console.ReadLine());
                            Search(id);
                            break;
                        }
                    case 5:
                        {
                            ListStudents();
                            break;
                        }




                }
                Console.WriteLine("Do you want to repeat");
                ch = Console.ReadLine();
            }
        }
        static void InsertRecords(Student student)
        {


            StudentDBContext db = new StudentDBContext();
            db.Students.Add(student);
            db.SaveChanges();
        }
        static void ListStudents()
        {
            StudentDBContext db = new StudentDBContext();
            var students = db.Students.ToList();
            foreach (Student temp in students)
                Console.WriteLine(temp.Id + " " + temp.Name + " " + temp.Batch + " " + temp.Marks);

        }
        static void Search(int id)
        {
            StudentDBContext db = new StudentDBContext();
            Student temp = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)

                Console.WriteLine(temp.Id + " " + temp.Name + " " + temp.Batch + " " + temp.Marks);


        }

        static void Delete(int id)
        {
            StudentDBContext db = new StudentDBContext();
            Student temp = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                db.Students.Remove(temp);
            db.SaveChanges();
        }
        static void Update(int id, Student student)
        {
            StudentDBContext db = new StudentDBContext();
            Student temp = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                foreach(Student obj in db.Students)
                {
                    if(obj.Id==id)
                    {
                        obj.Name = student.Name;
                        obj.Batch = student.Batch;
                        obj.Marks = student.Marks;
                        break;
                    }
                }
            db.SaveChanges();
            db.SaveChanges();
        }


    }

}
