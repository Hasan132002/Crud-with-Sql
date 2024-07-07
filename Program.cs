using System;
class Program{
    static void Main(string[] args){
        string connectionString="Server=localhost;Database=c_connect;Uid=root;password=;";
        Database db = new Database(connectionString);
        UserOperations userOps = new UserOperations(db);
        while (true){
            Console.WriteLine("Choose an Option:");
            Console.WriteLine("1 Insert");
            Console.WriteLine("2 Delete");
            Console.WriteLine("3 Update");
            Console.WriteLine("4 View");
            Console.WriteLine("5 Exit");

            string choice =Console.ReadLine();
            switch(choice)
            {
                case "1":
                Console.Write("Enter First Name:");
                string firstName=Console.ReadLine();
                Console.Write("Enter Last Name:");
                string lastName=Console.ReadLine();
                Console.Write("Enter Email:");
                string email=Console.ReadLine();
                Console.Write("Enter Age:");
                int age = int.Parse(Console.ReadLine());
                userOps.CreateUser(firstName,lastName,email,age);
                break;
                case "2":
                Console.Write("Enter User ID to Delete:");
                int deletedId = int.Parse(Console.ReadLine());
                userOps.DeleteUser(deletedId);
                break;
                case "3":
                Console.Write("Enter User ID to Update:");
                int updatedId = int.Parse(Console.ReadLine());
                Console.Write("Enter New First Name:");
                string newFirstName = Console.ReadLine();
                Console.Write("Enter New Last Name:");
                string newLastName = Console.ReadLine();
                Console.Write("Enter New Email:");
                string newEmail = Console.ReadLine();
                Console.Write("Enter New Age:");
                int newAge = int.Parse(Console.ReadLine());
                userOps.UpdateUser(updatedId, newFirstName, newLastName, newEmail, newAge);
                break;
                case "4":
                userOps.ReadUsers();
                break;
                case "5":
                return ;
                default:
                Console.WriteLine("Invalid Choice Please try Again");
                break;

                
            }
                
                        }

    }
}