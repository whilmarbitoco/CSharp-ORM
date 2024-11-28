namespace ORM.Model {

public class User : Model<User> {

    public String? Name{set;get;}
    public String? Email{set;get;}

    public User() {
        modelName = "User";
    }

    public User(String name, String email) {
        Name = name;
        Email = email;
    }
}
}