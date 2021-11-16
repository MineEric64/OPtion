using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OPtion
{
    public class OPtion
    {
        public bool IsLoaded { get; private set; }

        public JObject Data { get; set; } = new JObject();

        public OPtion()
        {
            IsLoaded = false;
        }

        public void Load(string path)
        {
            string text = File.ReadAllText(path);
            LoadText(text);
        }

        public void LoadText(string text)
        {
            Data = JObject.Parse(text);
            IsLoaded = true;
        }

        public void Save(string path)
        {
            File.WriteAllText(path, Data.ToString());
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
