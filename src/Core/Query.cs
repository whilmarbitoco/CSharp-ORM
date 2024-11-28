using ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ORM.Core {

    public class Query<T> where T : Model<T>, new() {

        protected List<T> Data;
        
        private List<T> tempData;

        public Query() {
            Data = new List<T>();
            tempData = new List<T>(Data);
        }

        public Query<T> insert(T data) {
            data.Id = generateId();
            Data.Add(data);
            tempData.Add(data);  
            return this;
        }

        public Query<T> deleteById(int id) {
            T? item = findById(id);
            if (item != null) {
                Data.RemoveAt(Data.IndexOf(item));
                tempData.RemoveAt(tempData.IndexOf(item)); 
            }
            return this;
        }

        public Query<T> updateById(int id, Action<T> updateAction) {
            T? item = findById(id);
            if (item != null) {
                updateAction(item);
                tempData = new List<T>(Data); 
            }
            return this;
        }


        public Query<T> where(Func<T, bool> predicate) {
            tempData = tempData.Where(predicate).ToList(); 
            return this;
        }
        
        public Query<T> sortBy<TKey>(Func<T, TKey> keySelector, bool ascending = true) {
            tempData = ascending 
                ? tempData.OrderBy(keySelector).ToList() 
                : tempData.OrderByDescending(keySelector).ToList();
            return this;
        }

        public List<T> getResult() {
            List<T> res = tempData;
            tempData =  new List<T>(Data);
            return res;
        }

        public List<T> findAll() {
            return Data;
        }

        public T? findById(int id) {
            return Data.FirstOrDefault(data => data.Id == id);
        }

        public int generateId() {
            return (int)((int)Data.Count + (0.5 * Data.Count));
        }
    }
}
