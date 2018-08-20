using AoC2017.Day19;
using NUnit.Framework;

namespace AoC2017.Tests.Day19
{
    public class Day19Part2Test
    {
        private Day19Part2 _sut;

        [SetUp]
        public void BeforeEach()
        {
            _sut = new Day19Part2();
        }

        [Test]
        public void Test1()
        {
            var result = _sut.Solution(
                @"
|
|
A
|
|
B
|
|
C
");
            Assert.That(result, Is.EqualTo(9));

        }

        [Test]
        public void Test2()
        {
            var result = _sut.Solution(
                @"
|
Q
+ABC

");
            Assert.That(result, Is.EqualTo(6));
        }


        [Test]
        public void Test2b()
        {
            var result = _sut.Solution(
                @"
     |
     Q
     |
CBA--+

");
            Assert.That(result, Is.EqualTo(9));
        }


        [Test]
        public void Test3()
        {
            var result = _sut.Solution(
                @"
  |
D-|-C-+
  A   |
  +-B-+

");
            Assert.That(result, Is.EqualTo(16));
        }



        [Test]
        public void Test4()
        {
            var result = _sut.Solution(
                @"
  |
  |   +-C-+
  A   |   D
  +-B-+   |
          +E--
");
            Assert.That(result, Is.EqualTo(20));
        }



        [Test]
        public void Test5()
        {
            var result = _sut.Solution(
@"
     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     |B-+  +--+ 
");
            Assert.That(result, Is.EqualTo(38));
        }


        [Test]
        public void Test5b()
        {
            var result = _sut.Solution(
@"
     |          
     |  +--+    
     A  |  C    
 F---+----E|--+ 
     |  |  |  D 
     +B-+  +--+ 
");
            Assert.That(result, Is.EqualTo(38));
        }



        [Test]
        public void Test6()
        {
            var result = _sut.Solution(Input.INPUT);

            Assert.That(result, Is.EqualTo(17302));

        }

    }

}
