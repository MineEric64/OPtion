using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace syntaxERROR.OPtion
{
    public class OPtion<T> where T : JToken
    {
        public bool IsLoaded { get; private set; }

        public T Data { get; set; }
        public string Path { get; set; } = string.Empty;

        public OPtion(string path)
        {
            IsLoaded = false;
            Path = path;
        }

        public void Load(string path)
        {
            string text = File.ReadAllText(path);
            LoadText(text);
        }

        public void LoadText(string text)
        {
            Data = (T)JToken.Parse(text);
            IsLoaded = true;
        }

        public void Save()
        {
            File.WriteAllText(Path, Data.ToString());
        }

        public void Sync(JObject oldToken, JObject newToken)
        {
            foreach (var oldItem in oldToken)
            {
                foreach (var newItem in newToken)
                {
                    if (oldItem.Key == newItem.Key)
                    {
                        newToken[newItem.Key] = oldItem.Value;
                    }
                }
            }
        }
    }
}
