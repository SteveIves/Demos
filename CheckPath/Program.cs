using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var folders = new List<String>(Environment.GetEnvironmentVariable("PATH").Split(';'));

            //Look for duplicate folders
            var dupsReported = false;
            var duplicates = new Dictionary<String,long>();
            foreach (string folder in folders)
            {
                long count = folders.LongCount(f => f.ToLower().Equals(folder.ToLower()));
                if (count>1)
                {
                    if (!dupsReported)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("These folders are in your path multiple times:");
                        dupsReported = true;
                    }
                    try
                    {
                        duplicates.Add(folder, count - 1);
                        Console.WriteLine("    - {0} ({1} times)", folder, count);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            //If we found duplicates then remove them so we don't check/report missing folders multiple times.
            foreach (var item in duplicates)
                for (int ix = 0; ix < item.Value; ix++)
                    folders.Remove(item.Key);

            //Look for folders that don't exist
            var missingReported = false;
            foreach (string folder in folders)
            { 
                if (!Directory.Exists(folder))
                {
                    if (!String.IsNullOrWhiteSpace(folder))
                    {
                        if (!missingReported)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("These PATH folders don't exist:");
                            missingReported = true;
                        }
                        Console.WriteLine("    - {0}", folder);
                    }
                }
            }

            if (!dupsReported && !missingReported)
            {
                Console.WriteLine("");
                Console.WriteLine("No PATH issues found");
            }
        }
    }
}
