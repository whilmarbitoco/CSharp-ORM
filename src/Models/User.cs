
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

    public User? getByEmail(String email) {

        foreach(User user in model) {
            if(user.Email == email) {
                return user;
            }
        }

        return null;
    }


}