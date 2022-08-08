using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace addressBook
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string path = @"C:\projects\address_book1.txt";
            string name, email;
            int age;
            string lines;
            UserContainer usercontainer;
            //UserDetails user = new UserDetails(); 




            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path)) ;

                using (StreamWriter sw = new StreamWriter(path))
                {
                    usercontainer = new UserContainer(); 
                    usercontainer.UserDetailList = new List<UserDetails>();
                    sw.WriteLine(JsonConvert.SerializeObject(usercontainer));
               
                    sw.Close();
                }
            }
                Console.WriteLine("Hi!! Welcome to Address Book. \n\nPlease select one option: \n\nPress 1: To create new user. \nPress 2: To display existing users. \nPress 3:To search a user." );
                int userChoice = int.Parse(Console.ReadLine());
          
            using (StreamReader sr = new StreamReader(path))
            {
                 lines = File.ReadAllText(path);

               // Console.WriteLine(lines);
                //Console.ReadLine();
                usercontainer = JsonConvert.DeserializeObject<UserContainer>(lines);
            }


            switch (userChoice)
                {
                    case 1:

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            
                            //initializing an empty list 

                            UserDetails user = new UserDetails(); //initializing empty object that goes in list 
                            Console.WriteLine("Enter your name: ");
                            name = Console.ReadLine();

                            Console.WriteLine("Enter your Email: ");
                            email = Console.ReadLine();

                            Console.WriteLine("Enter age: ");
                            age = int.Parse(Console.ReadLine());

                            user.Name = name; 
                            user.Email = email;
                            user.Age = age;

                            usercontainer.UserDetailList.Add(user);
                        Console.WriteLine(JsonConvert.SerializeObject(usercontainer));
                        sw.WriteLine(JsonConvert.SerializeObject(usercontainer));
                            Console.WriteLine("User's details have been saved.");
                         
                            sw.Close();
                           
                        }
                        break;

                    case 2:


                            Console.WriteLine(lines);
                            Console.ReadLine(); 
                        
                        break;
                    case 3:


                            Console.WriteLine("Enter name to search: ");
                            string searchName = Console.ReadLine();


                            foreach (UserDetails ud in usercontainer.UserDetailList)
                            {
                                if (ud.Name == searchName)
                                {
                                    Console.WriteLine("User's name is {0}, email is {1} and age is {2}", ud.Name, ud.Email, ud.Age);
                                    
                                }
                            }
                       

                        
                        break;
                    default:

                        Console.WriteLine("Please select one option from the beforementioned menu.");
                        Console.ReadLine();
                        break;
                }

            Console.WriteLine("Thank you");
            Console.ReadLine();





        }
    }
}
[Serializable] 

class UserDetails
{
    public string Name;
    public string Email;
    public int Age;  
}

[Serializable]

class UserContainer
{
    public List<UserDetails> UserDetailList;
}

