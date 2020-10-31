using PocketNET.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PocketNET.Core.Config
{
    public class JsonConfig
    {
        private Dictionary<string, object> _json = new Dictionary<string, object>();
        private string route { get; set; }

        public JsonConfig(string route)
        {
            this.route = route;

            try
            {
                if (File.Exists(route))
                {
                    _json = JsonSerializer.Deserialize<Dictionary<string, object>>(File.ReadAllText(route));
                }
            }
            catch (IOException e)
            {
                Logger.Error(e.Message);
            }
        }

        public string GetString(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return null;
            }

            return _json[key].ToString();
        }

        public int GetInt32(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToInt32(_json[key]);
        }

        public long GetInt64(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToInt64(_json[key]);
        }

        public short GetInt16(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToInt16(_json[key]);
        }

        public float GetFloat(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToSingle(_json[key]);
        }

        public double GetDouble(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToDouble(_json[key]);
        }

        public bool GetBool(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return false;
            }

            return Convert.ToBoolean(_json[key]);
        }

        public byte GetByte(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return 0;
            }

            return Convert.ToByte(_json[key]);
        }

        public decimal GetDecimal(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToDecimal(_json[key]);
        }

        public sbyte GetSByte(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToSByte(_json[key]);
        }

        public uint GetUInt32(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return 0;
            }

            return Convert.ToUInt32(_json[key]);
        }

        public ulong GetUInt64(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return 0;
            }

            return Convert.ToUInt64(_json[key]);
        }

        public ushort GetUShort(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return 0;
            }

            return Convert.ToUInt16(_json[key]);
        }

        public object GetObject(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return null;
            }

            return _json[key];
        }

        public object Get(string key)
        {
            if (!_json.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return null;
            }

            return _json[key];
        }

        public Dictionary<string, object> GetAll()
        {
            return _json;
        }

        public void Set(string key, object value)
        {
            if (!_json.ContainsKey(key))
            {
                _json.Add(key, value);

                return;
            }

            _json[key] = value;
        }

        public bool Remove(string key)
        {
            if (_json.ContainsKey(key)) return false;

            _json.Remove(key);

            return true;
        }

        public void Clear()
        {
            _json.Clear();
        }

        public int Count()
        {
            return _json.Count;
        }

        public bool Contains(string key)
        {
            return _json.ContainsKey(key);
        }

        public void Save()
        {
            try
            {
                File.WriteAllText(route, JsonSerializer.Serialize(_json));
            }
            catch (IOException e)
            {
                Logger.Error(e.Message);
            }
        }
    }
}
