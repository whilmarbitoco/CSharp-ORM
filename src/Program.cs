using ORM.Model;

namespace ORM {
class Program {
    static void Main() {
        Models models = new Models();

        User u = new User("John", "john@john.com");
        models.MUser.add(u);

        User? test = models.MUser.getById(0);

        bool r = models.MUser.delById(test.Id);

        System.Console.WriteLine(r ? "Deleted" : "Cannot Delete");

        foreach (User user in models.MUser.getAll()) {
            System.Console.WriteLine("> " + user.Name);
        }
       
    }

}

}