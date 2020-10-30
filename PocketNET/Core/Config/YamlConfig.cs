using PocketNET.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace PocketNET.Core.Config
{
    public class YamlConfig
    {
        private Dictionary<string, object> _config = new Dictionary<string, object>();
        private string route;

        public YamlConfig(string route)
        {
            this.route = route;
              
            try
            {
                if (File.Exists(route))
                {
                    var yaml = new YamlStream();

                    yaml.Load(new StringReader(File.ReadAllText(route)));

                    var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

                    foreach (var entry in mapping.Children)
                    {
                        _config.Add(entry.Key.ToString(), entry.Value);
                    }
                }

            }
            catch (YamlException e)
            {
                Logger.Error(e.Message);
            }
            catch (IOException e)
            {
                Logger.Error(e.Message);
            }
        }

        public string GetString(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return null;
            }

            return _config[key].ToString();
        }

        public int GetInt32(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToInt32(_config[key]);
        }

        public long GetInt64(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToInt64(_config[key]);
        }

        public short getInt16(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToInt16(_config[key]);
        }

        public float GetFloat(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToSingle(_config[key]);
        }

        public double GetDouble(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToDouble(_config[key]);
        }

        public bool GetBool(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return false;
            }

            return Convert.ToBoolean(_config[key]);
        }

        public byte GetByte(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return 0;
            }

            return Convert.ToByte(_config[key]);
        }

        public decimal GetDecimal(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToDecimal(_config[key]);
        }

        public sbyte GetSByte(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return -1;
            }

            return Convert.ToSByte(_config[key]);
        }

        public uint GetUInt32(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return 0;
            }

            return Convert.ToUInt32(_config[key]);
        }

        public ulong GetUInt64(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return 0;
            }

            return Convert.ToUInt64(_config[key]);
        }

        public ushort GetUShort(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return 0;
            }

            return Convert.ToUInt16(_config[key]);
        }

        public object GetObject(string key)
        {
            if (!_config.ContainsKey(key))
            {
                Logger.Warning("Config: Object [key:" + key + "] not found in " + route);

                return null;
            }

            return _config[key];
        }

        public Dictionary<string, object> GetAll()
        {
            return _config;
        }

        public void Set(string key, object value)
        {
            if (!_config.ContainsKey(key))
            {
                _config.Add(key, value);

                return;
            }

            _config[key] = value;
        }

        public bool Remove(string key)
        {
            if (_config.ContainsKey(key)) return false;

            _config.Remove(key);

            return true;
        }

        public bool Contains(string key)
        {
            return _config.ContainsKey(key);
        } 

        public void Save()
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(_config);

            File.WriteAllText(route, yaml);
        }
    }
}
