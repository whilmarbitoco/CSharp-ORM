public class Model<T> where T : Model<T> {

    protected List<T> model;
    protected String? modelName;

    public int Id{get;set;}
    public DateTime CreatedAt{get;set;}

    public Model() {
        model = new List<T>();
    }

    public void add(T data) {
        data.Id = generateId();
        data.CreatedAt = DateTime.Now;
        model.Add(data);
    }

    public T? getById(int id) {

        foreach (T m in model) {
            if (m.Id == id) {
                return m;
            }
        }
        
        return null;
    }    

    public List<T> getAll() {
        return model;
    }

    public bool delById(int id) {
        T? data = getById(id);

        if (data == null) {
            return false;
        }

        model.RemoveAt(model.IndexOf(data));
        return true;
    }

    public int generateId() {
        return (int)((int) model.Count + (0.5 * model.Count));
    }

}