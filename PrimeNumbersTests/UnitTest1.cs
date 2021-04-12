using System;
using Xunit;
using PrimeNumbers;

namespace PrimeNumbersTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(10, 29)]
        [InlineData(2, 3)]
        [InlineData(3, 5)]
        [InlineData(17, 59)]
        [InlineData(20, 71)]
        [InlineData(26, 101)]
        [InlineData(417, 2879)]

        public void SequencePrime(int seqNo, int digit)
        {
            PrimeCalc seq = new PrimeCalc();
            Assert.Equal(digit, seq.GetPrime(seqNo));
        }
    }
}
