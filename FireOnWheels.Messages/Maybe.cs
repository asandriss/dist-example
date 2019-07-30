using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireOnWheels.Messages
{
    public class Maybe<T> : IEnumerable<T>
    {
        private IEnumerable<T> _result;
        public Maybe()
        {
            _result = new T[0];
        }

        public Maybe(T value)
        {
            _result = new T[] { value };
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _result.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
