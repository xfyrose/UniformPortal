using System.Text;
using Util.Core;

namespace Util.Domains
{
    public class StateDescription
    {
        private StringBuilder _description;

        public override string ToString()
        {
            _description = new StringBuilder();

            AddDescriptions();

            return _description.ToString().TrimEnd().TrimEnd(',');
        }

        protected virtual void AddDescriptions()
        {
        }

        protected void AddDescription(string description)
        {
            if (description.IsEmpty())
            {
                return;
            }

            _description.Append(description);
        }

        protected void AddDescription<T>(string name, T value)
        {
            if (value.ToStr().IsEmpty())
            {
                return;
            }

            _description.AppendFormat("{0}:{1}", name, value);
        }
    }
}