using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.Models
{
    static class StoreService
    {
        private static object threadLock = new object();

        public static Dictionary<string, ViewModelStore> modelRepo = new Dictionary<string, ViewModelStore>();

        public static T GetStore<T>() where T : ViewModelStore, new()
        {
            lock (threadLock)
            {
                string modelName = typeof(T).ToString();
                if (modelRepo.ContainsKey(modelName))
                {
                    Debug.WriteLine("####Found model returning it");
                    return (T)modelRepo[modelName];
                }
                else
                {
                    Debug.WriteLine("###Model did not exist creating it");
                    //if we yet do not have a model of this type, we create it
                    T newModel = new T();
                    modelRepo.Add(modelName, newModel);
                    return newModel;
                }
            }
        }
    }
}
