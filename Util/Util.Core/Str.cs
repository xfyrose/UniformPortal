using System.Text;

namespace Util.Core
{
    public sealed partial class Str
    {
        public Str()
        {
        }

        private StringBuilder Builder { get; set; } = new StringBuilder();

        public void Add<T>(T value)
        {
            Builder.Append(value);
        }

        public void Add(string value, params object[] args)
        {
            if (args == null)
            {
                args = new object[] { string.Empty };
            }

            if (args.Length == 0)
            {
                Builder.Append(value);
            }
            else
            {
                Builder.AppendFormat(value, args);
            }
        }

        public void AddLine()
        {
            Builder.AppendLine();
        }

        public void AddLine<T>(T value)
        {
            Add(value);
            AddLine();
        }

        public void AddLine(string value, params object[] args)
        {
            Add(value, args);
            AddLine();
        }

        public void RemovedEnd(string end)
        {
            string result = Builder.ToString();

            if (!result.EndsWith(end))
            {
                return;
            }

            int index = result.LastIndexOf(end, System.StringComparison.Ordinal);
            Builder = Builder.Remove(index, end.Length);
        }

        public void Clear()
        {
            Builder = Builder.Clear();
        }

        public int Length => Builder.Length;

        public override string ToString()
        {
            return Builder.ToString();
        }
    }
}