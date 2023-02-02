using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AGVDispatcher.Util
{
    [Serializable]
    public class DictSerializeWrapper<TK,TV>
    {
        [XmlArray(ElementName = "Elements")]
        [XmlArrayItem(ElementName = "Element")]
        public List<KeyValueElement<TK,TV>> SerializableDictionary
        {
            get { return RealDictionary.Select(x => new KeyValueElement<TK,TV> { Key = x.Key, Value = x.Value }).ToList(); }
            set { RealDictionary = value.ToDictionary(x => x.Key, x => x.Value); }
        }

        [XmlIgnore]
        public Dictionary<TK, TV> RealDictionary { get; private set; }

        public DictSerializeWrapper() { }

        public DictSerializeWrapper(Dictionary<TK, TV> dict)
        {
            RealDictionary = dict;
        }
    }

    [Serializable]
    public class KeyValueElement<TK,TV>
    {
        public TK Key { get; set; }
        public TV Value { get; set; }
    }
}
