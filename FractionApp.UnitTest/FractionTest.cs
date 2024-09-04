namespace FractionApp.UnitTest
{
    public class FractionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        public void Fraction_Operators_CheckBooleanOperators()
        {
            // Arrange
            Fraction expected = new(1, 2);


            // Act
  
            Fraction actualEqual = new(1,2);
            Fraction actualLess = new(1,3);
            Fraction actualMore = new(2,3);
            


            // Assert
            Assert.That(actualEqual, Is.EqualTo(expected));
            Assert.That(actualLess, Is.LessThan(expected));
            Assert.That(actualMore, Is.GreaterThan(expected));
            Assert.That(actualEqual, Is.AtLeast(expected));
            Assert.That(actualEqual, Is.AtMost(expected));
        }

        [Test]
        public void Fraction_Operators_CheckMathOperators()
        {
            // Arrange
            Fraction expectedPluss = new(1,2);

            Fraction expectedMult = new(1, 16);

            Fraction expectedDiv = new(1, 1);

            Fraction expectedMinus = new(0, 1);


            // Act
            Fraction tmp1 = new(1 , 4);
            Fraction tmp2 = new(1, 4);
            Fraction actualPluss = tmp1 + tmp2;
            Fraction actualMult = tmp1 * tmp2;
            Fraction actualDiv = tmp1 / tmp2;
            Fraction actualMinus = tmp1 - tmp2;


            // Assert
            Assert.That(actualPluss,Is.EqualTo(expectedPluss));
            Assert.That(actualMult, Is.EqualTo(expectedMult));
            Assert.That(actualDiv, Is.EqualTo(expectedDiv));
            Assert.That(actualMinus, Is.EqualTo(expectedMinus));
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
