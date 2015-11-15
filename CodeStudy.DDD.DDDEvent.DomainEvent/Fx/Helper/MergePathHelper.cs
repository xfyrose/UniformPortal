using System;

namespace DomainEvent.Fx.Helper
{
    /// <summary>
    ///     Merge Path Helper
    /// </summary>
    public class MergePathHelper
    {
        /// <summary>
        ///     Merge File Path
        /// </summary>
        /// <param name="codeBasePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string MergeFilePath(string codeBasePath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(codeBasePath) || string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            var path = codeBasePath;
            var webMode = false;

            var i = path.LastIndexOf(@"/", StringComparison.Ordinal);

            if (i > 0)
            {
                path = path.Remove(i);
                webMode = true;
            }

            if (webMode)
            {
                if (!fileName.StartsWith(@"/"))
                    fileName = @"/" + fileName;
            }
            else
            {
                if (!fileName.StartsWith(@"\"))
                    fileName = @"\" + fileName;
            }

            path = path + fileName;

            return path;
        }

        /// <summary>
        ///     Merge File Path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string MergeFilePath(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            var path = AppDomain.CurrentDomain.BaseDirectory;
            var webMode = false;

            var i = path.LastIndexOf("/", StringComparison.Ordinal);

            if (i > 0)
            {
                path = path.Remove(i);
                webMode = true;
            }

            if (webMode)
            {
                if (!fileName.StartsWith(@"/"))
                    fileName = @"/" + fileName;
            }
            else
            {
                if (!fileName.StartsWith(@"\"))
                    fileName = @"\" + fileName;
            }

            path = path + fileName;

            return path;
        }
    }
}