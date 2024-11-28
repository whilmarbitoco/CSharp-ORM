using ORM.Model;
using System;

namespace ORM {
    class Program {
        static void Main() {
            // Initialize the models and User Query
            Models models = new Models();
            
            // Create and insert dummy users
            models.MUser.insert(new User("John", "john@john.com"));
            models.MUser.insert(new User("Jane", "jane@jane.com"));
            models.MUser.insert(new User("Alice", "alice@alice.com"));
            models.MUser.insert(new User("Bob", "bob@bob.com"));
            models.MUser.insert(new User("Charlie", "charlie@charlie.com"));
            models.MUser.insert(new User("Diana", "diana@diana.com"));
            models.MUser.insert(new User("Eve", "eve@eve.com"));
            models.MUser.insert(new User("Frank", "frank@frank.com"));
            models.MUser.insert(new User("Grace", "grace@grace.com"));
            models.MUser.insert(new User("Hank", "hank@hank.com"));

            // Display all users
            Console.WriteLine("All Users:");
            foreach (User user in models.MUser.findAll()) {
                Console.WriteLine($"> {user.Name} :: {user.Id}");
            }

            // Find user by ID (ID = 1)
            User? userById = models.MUser.findById(1);
            Console.WriteLine($"\nUser with ID 1: {userById?.Name}");

            // Delete a user by ID (ID = 2)
            models.MUser.deleteById(3);
            Console.WriteLine("\nUser with ID 3 has been deleted.");

            // Display all users after deletion
            Console.WriteLine("\nAll Users After Deletion:");
            foreach (User user in models.MUser.findAll()) {
                Console.WriteLine($"> {user.Name} :: {user.Id}");
            }

            // Update user with ID 3 (change name to "Alice Updated")
            models.MUser.updateById(6, u => u.Name = "Alice Updated");
            Console.WriteLine("\nUser with ID 6 has been updated.");

            // Display all users after update
            Console.WriteLine("\nAll Users After Update:");
            foreach (User user in models.MUser.findAll()) {
                Console.WriteLine($"> {user.Name} :: {user.Id}");
            }

            // Find users where the name starts with 'A'
            var usersWithA = models.MUser.where(u => u.Name.StartsWith("A")).getResult();
            Console.WriteLine("\nUsers whose name starts with 'A':");
            foreach (User user in usersWithA) {
                Console.WriteLine($"> {user.Name} :: {user.Id}");
            }

            // Sort users by name (ascending)
            var sortedUsers = models.MUser.sortBy(u => u.Name).getResult();
            Console.WriteLine("\nUsers sorted by name (ascending):");
            foreach (User user in sortedUsers) {
                Console.WriteLine($"> {user.Name} :: {user.Id}");
            }

            // Sort users by name (descending)
            var sortedUsersDesc = models.MUser.sortBy(u => u.Name, false).getResult();
            Console.WriteLine("\nUsers sorted by name (descending):");
            foreach (User user in sortedUsersDesc) {
                Console.WriteLine($"> {user.Name} :: {user.Id}");
            }
        }
    }
}
