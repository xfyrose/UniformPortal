using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Util.Core.Validations
{
    public class ValidationResultCollection : IEnumerable<ValidationResult>
    {
        public ValidationResultCollection()
        {
            _results = new List<ValidationResult>();
        }

        private readonly List<ValidationResult> _results;

        public bool IsValid => _results.Count == 0;

        public int Count => _results.Count;

        public void Add(ValidationResult result)
        {
            if (result == null)
            {
                return;
            }

            _results.Add(result);
        }

        public void AddResults(IEnumerable<ValidationResult> results)
        {
            if (results == null)
            {
                return;
            }

            _results.AddRange(results);
        }

        IEnumerator<ValidationResult> IEnumerable<ValidationResult>.GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }
    }
}