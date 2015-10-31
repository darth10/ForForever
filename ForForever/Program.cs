using System;

namespace ForForever
{
    class RandomRefType
    {
        public String StringProp { get; set; }
        public int IntProp { get; set; }
        public double FloatProp { get; set; }
    }

    struct RandomValueType
    {
        public String StringProp { get; set; }
        public int IntProp { get; set; }
        public double FloatProp { get; set; }
    }

    class Program
    {
        static RangeHelper _rangeHelper = new RangeHelper();
        static TestHelper _testHelper = new TestHelper();

        static void Main(string[] args)
        {
            var n = 1000000;

            var objs = _rangeHelper.GetArray<RandomRefType>(n);
            var vals = _rangeHelper.GetArray<RandomValueType>(n);

            // TODO comments

            _testHelper.RunTestsAndPrint(
                objs,
                c => _testHelper.RunWithFor(c),
                3, "for with List<T>");

            _testHelper.RunTestsAndPrint(
                objs,
                c => _testHelper.RunWithForEach(c),
                3, "foreach with List<T>");

            _testHelper.RunTestsAndPrint(
                vals,
                c => _testHelper.RunWithFor(c),
                3, "for with Array<T>");

            _testHelper.RunTestsAndPrint(
                vals,
                c => _testHelper.RunWithForEach(c),
                3, "foreach with Array<T>");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
