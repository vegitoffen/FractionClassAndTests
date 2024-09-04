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

        [Test]
        public void Constructor_FractionThatCanBeReduced_ReducedToSmallestValue_Wrong()
        {
            // Arrange
            Fraction expected = new(1, 2);


            // Act
            Fraction actual = new(3, 5);

            // Assert
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

    }
}