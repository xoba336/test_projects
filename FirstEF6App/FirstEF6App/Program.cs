using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEF6App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                /*User user1 = new User();
                User user2 = new User();

                user1.Name = "Alex";
                user1.Age = 30;
                user2.Name = "Bob";
                user2.Age = 27;
            

                db.Users.Add(user1);
                db.Users.Add(user2);

                //var name = db.Users.First().Name;

                db.SaveChanges();
                Console.WriteLine("Objects saved...");

                var users = db.Users;
                Console.WriteLine("Objects users from DB: ");
                foreach (User user in users)
                {
                    Console.WriteLine("{0}.{1}-{2}",user.Id, user.Name, user.Age);
                }*/





                /*var users = db.t_User;

                foreach (t_User user in users)
                {
                    //Console.WriteLine("{0}.{1}-{2}", user.Id, user.Name, user.Age);
                    Console.WriteLine("{0}.{1}.....{2} - {3}", user.Id, user.Name, user.Description, user.Count);
                }*/

                var animals = db.Animals.AsQueryable();
                var someTables = db.Sometables.AsQueryable();
                var users = db.Users.AsQueryable();

                foreach (Animals a in animals)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4}", a.Id, a.Name, a.Height, a.Weight, a.Nickname);
                }

                foreach (SomeTables a in someTables)
                {
                    Console.WriteLine("{0} - {1} - {2}", a.Id, a.Name, a.Count);
                }

                foreach (Users a in users)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", a.Id, a.Name, a.Age, a.Size);
                }

                List<Animals> an = animals.Where(x => x.Name.StartsWith("Cat")).ToList();




            }
            Console.Read();


        }
    }
}
