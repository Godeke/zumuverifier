using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainarizumuVerifier;

namespace MainarizumuTest
{
    [TestClass]
    public class MainarizumuTest
    {
        [TestMethod]
        public void Test2x2WithHorizontalGreaterThan()
        {
            const string puzzle = @"2
,>,
,,
,,";
            const string solution = @"2
2,>,1
,,
1,,2
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test2x2WithHorizontalLessThan()
        {
            const string puzzle = @"2
,<,
,,
,,";
            const string solution = @"2
1,<,2
,,
2,,1
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test2x2WithVerticalGreaterThan()
        {
            const string puzzle = @"2
,,
v,,
,,";
            const string solution = @"2
2,,1
v,,
1,,2
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test2x2WithVerticalLessThan()
        {
            const string puzzle = @"2
,,
^,,
,,";
            const string solution = @"2
1,,2
^,,
2,,1
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test2x2WithNumericClueThan()
        {
            const string puzzle = @"2
,1,
,,
,>,";
            const string solution = @"2
1,1,2
,,
2,>,1
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test3x3NoClues()
        {
            const string puzzle = @"3
,,,,
,,,,
,,,,
,,,,";
            const string solution = @"3
123,,123,,123
,,,,
123,,123,,123
,,,,
123,,123,,123
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test3x3WithSequenceGreater()
        {
            const string puzzle = @"3
,>,,>,
,,,,
,,,,
,,,,";
            const string solution = @"3
3,>,2,>,1
,,,,
12,,13,,23
,,,,
12,,13,,23
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test3x3WithSequenceLess()
        {
            const string puzzle = @"3
,<,,<,
,,,,
,,,,
,,,,";
            const string solution = @"3
1,<,2,<,3
,,,,
23,,13,,12
,,,,
23,,13,,12
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test5x5Sample()
        {
            const string puzzle = @"5
,<,3,,,,,,
,,,,,,,,
,,,,,<,,,
,,,,v,,,,
,,,<,,,,,
,,,,v,,,,
,2,,,,>,,,
,,,,,,,,
,,,,,,,,
";
            const string solution = @"5
2,<,3,,5,,4,,1
,,,,,,,,
1,,2,,4,<,5,,3
,,,,v,,,,
4,,1,<,3,,2,,5
,,,,v,,,,
3,2,5,,2,>,1,,4
,,,,,,,,
5,,4,,1,,3,,2
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

        [TestMethod]
        public void Test7x7Sample()
        {
            const string puzzle = @"7
,,,,,,,,,,,,
4,,,,,,,,,,,,V
,,,,,,,,,,,4,
,,6,,^,,,,3,,,,
,,,,,<,,,,,,,
,,,,,,^,,3,,,,v
,,,>,,,,,,,,,
,,v,,,,,,,,,,
,,,,,,,<,,,,,
,,,,,,,,,,,,
,,,,,,,,,>,,>,
,,,,^,,,,^,,,,
,,,,,,,,,,,,
";
            const string solution = @"7
1,,3,,6,,5,,2,,4,,7
4,,,,,,,,,,,,V
5,,1,,4,,3,,7,,2,4,6
,,6,,^,,,,3,,,,
2,,7,,5,<,6,,4,,1,,3
,,,,,,^,,3,,,,v
4,,5,>,3,,7,,1,,6,,2
,,v,,,,,,,,,,
6,,4,,1,,2,<,3,,7,,5
,,,,,,,,,,,,
7,,6,,2,,4,,5,>,3,>,1
,,,,^,,,,^,,,,
3,,2,,7,,1,,6,,5,,4
";
            Mainarizumu solver = new Mainarizumu(puzzle);
            Assert.AreEqual(solution, solver.GetSolution());
        }

    }
}
