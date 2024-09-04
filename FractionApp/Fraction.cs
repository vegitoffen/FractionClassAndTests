namespace FractionApp
{
	public class Fraction : IComparable<Fraction>
	{
		#region Properties

		public int Numerator { get; private set; }
		
		private int _denominator;
		public int Denominator 
		{ 
			get { 
				return _denominator; 
			} 
			private set {
				if (value != 0) {
					_denominator = value;
				} else {
					// Denominator should never be set to zero.
					throw new ArgumentOutOfRangeException(nameof(_denominator), value, $"The denominator can't be zero.");
				}
			} 
		}
		
		#endregion


        #region Constructors

		// By adding default values for both numerator and denominator, we also cover a parameterless constructor.
		public Fraction(int numerator = 0, int denominator = 1)
		{
            // Denominator should never stay negative (but numerator can do that).
            if (denominator < 0) {
                Numerator = -numerator;
                Denominator = -denominator;
            } else {
                Numerator = numerator;
                Denominator = denominator;
            }
            Reduce();
		}

		#endregion


		#region Instance Methods

		/// <summary>
		/// Reduces the fraction.
		/// </summary>
		/// <returns>Nothing (void).</returns>
		private void Reduce()
		{
			/*
            int greatestCommonDivisor = (int)MathUtil.GreatestCommonDivisor((uint)Math.Abs(Numerator), (uint)Math.Abs(Denominator));

            Numerator /= greatestCommonDivisor;
            Denominator /= greatestCommonDivisor;

            // Different Reduce solutions (by some earlier students)
            // Variant #1:
            var a = Numerator;
            var b = Denominator;
            var gcd = a % b;
            while (gcd > 0) {
                a = b;
                b = gcd;
                gcd = a % b;
            }
            Numerator = Numerator / b;
            Denominator = Denominator / b;
            */

			// Variant #2:
			for (int i = 2; i < Denominator; i++) {
                if (Numerator % i == 0 && Denominator % i == 0) {
                    Numerator /= i;
                    Denominator /= i;
                    i = 1; //so i = 2 when the loop starts again
                }
            }
		}


		public override string ToString()
		{
			return $"{Numerator}/{Denominator}";
		}


        // To students: We need this to compare Fractions in NUnit tests.
        //              This is also the first (of two) methods we're asked to override when we make operator == and != overloads.
        public override bool Equals(object? obj)
        {
            // If obj is an instance of class Fraction or instance of a class inheriting from Fraction
            if (obj is Fraction fraction) {
                // Compare using our other Equals method (below).
                return Equals(fraction);
            } else {
                return false;
            }
        }


        public bool Equals(Fraction otherFraction)
		{
			return Numerator * otherFraction.Denominator == otherFraction.Numerator * Denominator;
		}


		// To students: This is the second (of two) methods we're asked to override when we make operator == and != overloads.
		//              We're not focusing on GetHashCode() in this course, I just added it to remove the related VS warnings.
		public override int GetHashCode()
		{
			return Numerator ^ Denominator;
		}


		/// <summary>
		/// Compares this otherFraction to another.
		/// </summary>
		/// <param name="obj">The object we compare with.</param>
		/// <returns>Returns 0 if equal, 1 if greater and -1 if lesser.</returns>
		public int CompareTo(Fraction? otherFraction)
		{
			// NOTE: This method is required if we choose to implement the IComparable
			// interface (letting us sort Fractions stored in collections and the like.)

			if (otherFraction is null || this > otherFraction) {
				return 1;
			} else if (this == otherFraction) {
				return 0;
			} else {
				return -1;
			}
		}


		public float ToFloat()
		{
			// Need to cast at least one of them, to get float as answer (int / int gives int as answer).
			return Numerator / (float)Denominator;
		}


		public double ToDouble()
		{
			return Numerator / (double)Denominator;
		}


		public Fraction Negate()
		{
			return new Fraction(-Numerator, Denominator);
		}


		// Reciprocal: a / b flipped into b / a
		public Fraction Reciprocal()
		{
			return new Fraction(Denominator, Numerator);
		}


		public Fraction Add(Fraction otherFraction)
		{
			int newNumeratorResult = (Numerator * otherFraction.Denominator) + (otherFraction.Numerator * Denominator);

			int newDenominatorResult = Denominator * otherFraction.Denominator;

			return new Fraction(newNumeratorResult, newDenominatorResult);
		}


		public Fraction Substract(Fraction otherFraction)
		{
			return Add(-otherFraction);
		}


		public Fraction Multiply(Fraction otherFraction)
		{
			return new Fraction(Numerator * otherFraction.Numerator, Denominator * otherFraction.Denominator);
		}


		public Fraction Multiply(int number)
		{
			// For unit testing: Deliberately made an error.
			return new Fraction(Numerator + number, Denominator);
			// Correct version is this:
			//return new Fraction(Numerator * number, Denominator);
		}


		public Fraction Divide(Fraction otherFraction)
		{
			return Multiply(otherFraction.Reciprocal());
		}


		public Fraction Power(int power)
		{
			if (power == 1) {
				return new Fraction(Numerator, Denominator);
			}

			int numerator = (int)Math.Pow(Numerator, Math.Abs(power));
			int denominator = (int)Math.Pow(Denominator, Math.Abs(power));

			// (a/b)^-1 == 1/(a/b) == (b/a)
			// If powerRight less than zero return reciprocal.
			return power > 0 ? new Fraction(numerator, denominator) : new Fraction(denominator, numerator);
		}


		public bool GreaterThan(Fraction otherFraction)
		{
			return (Numerator * otherFraction.Denominator) > (otherFraction.Numerator * Denominator);
		}


		public bool LesserThan(Fraction otherFraction)
		{
			return !GreaterThanOrEqual(otherFraction);
		}


		public bool GreaterThanOrEqual(Fraction otherFraction)
		{
			return Equals(otherFraction) || GreaterThan(otherFraction);
		}


		public bool LesserThanOrEqual(Fraction otherFraction)
		{
			return !GreaterThan(otherFraction);
		}

		#endregion


		#region Operator Overloads

		public static bool operator ==(Fraction left, Fraction right)
		{
			return left.Equals(right);
		}


		public static bool operator !=(Fraction left, Fraction right)
		{
			return !(left == right);
		}


		public static bool operator >(Fraction left, Fraction right)
		{
			return left.GreaterThan(right);
		}


		public static bool operator <(Fraction left, Fraction right)
		{
			return left.LesserThan(right);
		}


		public static Fraction operator +(Fraction left, Fraction right)
		{
			return left.Add(right);
		}


		public static Fraction operator -(Fraction left, Fraction right)
		{
			return left.Substract(right);
		}


		public static Fraction operator *(Fraction left, Fraction right)
		{
			return left.Multiply(right);
		}


		public static Fraction operator *(Fraction left, int numberRight)
		{
			return left.Multiply(numberRight);
		}


		public static Fraction operator /(Fraction left, Fraction right)
		{
			return left.Divide(right);
		}


		public static Fraction operator ^(Fraction left, int powerRight)
		{
			return left.Power(powerRight);
		}


		public static Fraction operator ++(Fraction fraction)
		{
			return new Fraction(fraction.Numerator + fraction.Denominator, fraction.Denominator);
		}


		public static Fraction operator --(Fraction fraction)
		{
			return new Fraction(fraction.Numerator - fraction.Denominator, fraction.Denominator);
		}


		public static Fraction operator -(Fraction fraction)
		{
			return fraction.Negate();
		}


		public static implicit operator double (Fraction fraction)
		{
			return fraction.ToDouble();
		}


		public static implicit operator float (Fraction fraction)
		{
			return fraction.ToFloat();
		}


        public static explicit operator Fraction (double doubleValue) 
		{
            int denominator = 1;
            while (doubleValue - Math.Floor(doubleValue) != 0) {
                doubleValue *= 10;
                denominator *= 10;
                if (denominator >= 100000) break; // limit the denominator at the cost of accuracy
            }

            return new Fraction((int)doubleValue, denominator);
		}


        public static explicit operator Fraction (float floatValue) 
		{
            return (Fraction)((double)floatValue);
		}

        #endregion
    }
}
