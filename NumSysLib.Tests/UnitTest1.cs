using Xunit;
using NumSysLib;

namespace NumSysLib.Tests
{
    public class BinaryTests
    {
        [Fact]
        public void Convert_BinaryToDecimal_ReturnsExpectedResult()
        {
            var adapter = new Adapter();
            string input = "1101";
            string expected = "13";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_OctalToDecimal_ReturnsExpectedResult()
        {
            var adapter = new Adapter();
            string input = "77";
            string expected = "63";

            string actual = adapter.Convert(input, 8, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_InvalidSymbols_ThrowsException()
        {
            var adapter = new Adapter();
            string input = "102";

            Assert.Throws<ArgumentException>(() => adapter.Convert(input, 2, 10));
        }

        [Fact]
        public void Convert_EmptyInput_ThrowsException()
        {
            var adapter = new Adapter();
            string input = "";

            Assert.Throws<ArgumentException>(() => adapter.Convert(input, 2, 10));
        }

        [Fact]
        public void Convert_InvalidFromBase_ThrowsException()
        {
            var adapter = new Adapter();

            Assert.Throws<ArgumentException>(() => adapter.Convert("101", 1, 10));
        }

        [Fact]
        public void Convert_InvalidToBase_ThrowsException()
        {
            var adapter = new Adapter();

            Assert.Throws<ArgumentException>(() => adapter.Convert("101", 2, 17));
        }

        [Fact]
        public void Convert_Zero_ReturnsZero()
        {
            var adapter = new Adapter();
            string expected = "0";

            string actual = adapter.Convert("0", 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_MaxLongBinaryToDecimal_ReturnsExpectedResult()
        {
            var adapter = new Adapter();
            string input = new string('1', 63);
            string expected = "9223372036854775807";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_64BinaryOnes_DoesNotOverflow()
        {
            var adapter = new Adapter();
            string input = new string('1', 64);
            string expected = "18446744073709551615";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_70BinaryOnes_DoesNotOverflow()
        {
            var adapter = new Adapter();
            string input = new string('1', 70);
            string expected = "1180591620717411303423";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_LargeDecimalToBinary_DoesNotOverflow()
        {
            var adapter = new Adapter();
            string input = "18446744073709551615";
            string expected = new string('1', 64);

            string actual = adapter.Convert(input, 10, 2);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Convert_NegativeBinaryToDecimal_ReturnsExpectedResult()
        {
            var adapter = new Adapter();
            string input = "-1101";
            string expected = "-13";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_NegativeDecimalToBinary_ReturnsExpectedResult()
        {
            var adapter = new Adapter();
            string input = "-13";
            string expected = "-1101";

            string actual = adapter.Convert(input, 10, 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_NegativeOctalToDecimal_ReturnsExpectedResult()
        {
            var adapter = new Adapter();
            string input = "-77";
            string expected = "-63";

            string actual = adapter.Convert(input, 8, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_NegativeHexToDecimal_ReturnsExpectedResult()
        {
            var adapter = new Adapter();
            string input = "-FF";
            string expected = "-255";

            string actual = adapter.Convert(input, 16, 10);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_NegativeDecimalToHex_ReturnsExpectedResult()
        {
            var adapter = new Adapter();
            string input = "-255";
            string expected = "-FF";

            string actual = adapter.Convert(input, 10, 16);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_NegativeZero_ReturnsZero()
        {
            var adapter = new Adapter();
            string input = "-0";
            string expected = "0";

            string actual = adapter.Convert(input, 10, 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_OnlyMinus_ThrowsException()
        {
            var adapter = new Adapter();

            Assert.Throws<ArgumentException>(
                () => adapter.Convert("-", 10, 2));
        }

        [Fact]
        public void Convert_NegativeInvalidNumber_ThrowsException()
        {
            var adapter = new Adapter();
            string input = "-102";

            Assert.Throws<ArgumentException>(
                () => adapter.Convert(input, 2, 10));
        }

    }
}
