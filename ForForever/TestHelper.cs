using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ForForever
{
    class TestHelper
    {
        public void RunTestsAndPrint<T>(IEnumerable<T> coll,
                                        Action<IEnumerable<T>> collAction,
                                        int runs,
                                        String message)
        {
            var results = RunTests(coll, collAction, runs);
            var average = results.Average();

            Console.WriteLine(message + ":");
            Console.WriteLine("".PadRight(message.Length + 1, '-'));

            for (int i = 0; i < results.Length; i++)
                Console.WriteLine(String.Format("Run {0}: {1}ms", i, results[i]));

            Console.WriteLine(String.Format("Average time: {0}", average));
            Console.WriteLine();
        }

        public long[] RunTests<T>(IEnumerable<T> coll,
                                  Action<IEnumerable<T>> collAction,
                                  int runs)
        {
            var results = new long[runs];
            for (int i = 0; i < runs; i++)
            {
                var sw = Stopwatch.StartNew();
                collAction(coll);

                sw.Stop();
                results[i] = sw.ElapsedMilliseconds;
            }

            return results;
        }

        public void RunWithFor<T>(IEnumerable<T> coll)
        {
            String s;
            foreach (var val in coll)
            {
                s = val.ToString();
            }
        }

        public void RunWithForEach<T>(IEnumerable<T> coll)
        {
            var n = coll.Count();
            T val;
            String s;
            for (int i = 0; i < n; i++)
            {
                val = coll.ElementAt(i);
                s = val.ToString();
            }
        }
    }
}
