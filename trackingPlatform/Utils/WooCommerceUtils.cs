using System.Text;
using WooCommerceNET.Base;

namespace trackingPlatform.Utils
{
    public class WooCommerceUtils
    {
        public static string Slugify(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            input = input.Trim();
            var stringBuilder = new StringBuilder();
            foreach (char c in input.ToArray())
            {
                if (Char.IsLetterOrDigit(c))
                {
                    stringBuilder.Append(c);
                }
                else if (c == ' ')
                {
                    stringBuilder.Append("-");
                }
            }

            return stringBuilder.ToString().ToLower();
        }

        public static BatchObject<T> initBatch<T>()
        {
            BatchObject<T> batchObject = new BatchObject<T>();
            batchObject.create = new List<T>();
            batchObject.update = new List<T>();
            batchObject.delete = new List<ulong>();
            batchObject.DeletedItems = new List<T>();
            return batchObject;
        }
    }
}
