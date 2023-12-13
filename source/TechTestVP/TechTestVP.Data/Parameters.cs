using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestVP.Data
{
    public class Parameters
    {
        private readonly Dictionary<string, object> _values;

        public bool IsEmpty => _values.Count == 0;

        public Parameters()
        {
            _values = new Dictionary<string, object>();
        }

        public void Add( string name, object value)
        {
            _values.Add(name, value);
        }

        public IDictionary<string, object> GetValues()
        {
            return _values;
        }
    }
}
