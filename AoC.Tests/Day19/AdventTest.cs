using AoC2018.Day19;
using NUnit.Framework;

namespace AoC2018.Tests.Day19
{
    public class AdventTest
    {
        private Advent _sut;

        [SetUp]
        public void BeforeEach()
        {
            _sut = new Advent();
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
            Assert.That(result, Is.EqualTo("ABC"));

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
            Assert.That(result, Is.EqualTo("QABC"));
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
            Assert.That(result, Is.EqualTo("QABC"));
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
            Assert.That(result, Is.EqualTo("ABCD"));
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
            Assert.That(result, Is.EqualTo("ABCDE"));
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
            Assert.That(result, Is.EqualTo("ABCDEF"));
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
            Assert.That(result, Is.EqualTo("ABCDEF"));
        }



        [Test]
        public void Test6()
        {
            var result = _sut.Solution(Input.INPUT);

            Assert.That(result, Is.EqualTo("LXWCKGRAOY"));

        }

    }
}
