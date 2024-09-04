namespace FractionApp.UnitTest
{
    public class FractionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_FractionThatCanBeReduced_ReducedToSmallestValue()
        {
            // Arrange
            Fraction expected = new(1,2);


            // Act
            Fraction actual = new(3 , 6);

            // Assert
            Assert.That(actual,Is.EqualTo(expected));
        }

        [TestCase(-1,2,1,-2),
         TestCase(1,2,2,4),
          TestCase(0,1)]
        public void Constructor_Initialization_CorrectInitialization( int exp1,int exp2, int num11=0, int num12=0)
        {
            // Arrange       
            Fraction expected = new(exp1, exp2);


            // Act
            Fraction actual = new();
            if (!(num11 == 0 && num12 == 0)) { actual = new(num11, num12); }
            

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    }
