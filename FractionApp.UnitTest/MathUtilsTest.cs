using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionApp.UnitTest
{
    public class MathUtilsTest
    {

        [TestCase (8,12,4),
         TestCase (3,12,3),
         TestCase (7,21,7),
         TestCase (12,3,3)]
        public void MathUtils_GreatestCommonDivisor_CheckFunctionality( int num1, int num2, int exp) {

            // Arrange
            uint actual1 = (uint)num1;
            uint actual2 = (uint)num2;
            uint expected = (uint)exp;




            // Act
            uint actual = MathUtil.GreatestCommonDivisor(actual1, actual2);
            


            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        
        
        
        }

        [TestCase (0,0,0),
         TestCase(6,10,30),
         TestCase(3,7,21)
            ]
        public void MathUtils_LeastCommonMultiple_CheckFunctionality(int num1,int num2,int expected)
        {

            // Arrange


            // Act
            uint actual = MathUtil.LeastCommonMultiple((uint)num1, (uint)num2);


            // Assert

            Assert.That(actual,Is.EqualTo((uint)expected));

        }


    }
}
