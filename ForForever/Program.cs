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

            var arrayObjs = _rangeHelper.GetArray<RandomRefType>(n);
            var arrayVals = _rangeHelper.GetArray<RandomValueType>(n);
            var listObjs = _rangeHelper.GetList<RandomRefType>(n);
            var listVals = _rangeHelper.GetList<RandomValueType>(n);

            // TODO comments

            _testHelper.RunTestsAndPrint(
                arrayObjs,
                c => _testHelper.RunWithFor(c),
                5, "for with Array of ref types");

            _testHelper.RunTestsAndPrint(
                arrayObjs,
                c => _testHelper.RunWithForEach(c),
                5, "foreach with Array of ref types");

            _testHelper.RunTestsAndPrint(
                arrayVals,
                c => _testHelper.RunWithFor(c),
                5, "for with Array of value types");

            _testHelper.RunTestsAndPrint(
                arrayVals,
                c => _testHelper.RunWithForEach(c),
                5, "foreach with Array of value types");

            // TODO lists
            _testHelper.RunTestsAndPrint(
                listObjs,
                c => _testHelper.RunWithFor(c),
                5, "for with List of ref types");

            _testHelper.RunTestsAndPrint(
                listObjs,
                c => _testHelper.RunWithForEach(c),
                5, "foreach with List of ref types");

            _testHelper.RunTestsAndPrint(
                listVals,
                c => _testHelper.RunWithFor(c),
                5, "for with List of value types");

            _testHelper.RunTestsAndPrint(
                listVals,
                c => _testHelper.RunWithForEach(c),
                5, "foreach with List of value types");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
