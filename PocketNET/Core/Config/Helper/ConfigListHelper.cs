using System.Collections.Generic;

namespace PocketNET.Core.Config.Helper
{
    public class ConfigListHelper
    {
        private List<object> _list = new List<object>();
        private List<object> _parse { get; set; }

        public ConfigListHelper(string value)
        {
            object[] values = value.Split(":");

            foreach (object content in values) {
                _list.Add(content);
            }
        }

        public ConfigListHelper(List<object> list)
        {
            _parse = list;
        }

        public object Get(int index)
        {
            return _list[index];
        }

        public void Add(object value)
        {
            _list.Add(value);
        }

        public void Remove(object value)
        {
            if (_list.Contains(value)) _list.Remove(value);
        }

        public bool Contains(object value)
        {
            return _list.Contains(value);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int GetCount()
        {
            return _list.Count;
        }

        public string Build()
        {
            if (_parse.Count == 0) return "";

            string build = "";
            int max = (_parse.Count - 1);

            for (int i = 0; i < max; i++)
            {
                if (i < max) build += _parse[i] + ":";

                if (i == (max -1)) build += _parse[i];
            }

            return build;
        }
    }
}
