using Xunit;
using NumSysLib;

namespace NumSysLib.Tests
{
    public class BinaryTests
    {
        [Fact]
        public void Convert_BinaryTo10() // Базовый перевод 2-10
        {
            var adapter = new Adapter();
            string input = "1101";
            string expected = "13";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_OctTo10() // Базовый перевод 8-10
        {
            var adapter = new Adapter();
            string input = "77";
            string expected = "63";

            string actual = adapter.Convert(input, 8, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_InvalidSymbols() // Недопустимый символ
        {
            var adapter = new Adapter();
            string input = "102";

            Assert.Throws<ArgumentException>(() => adapter.Convert(input, 2, 10));
        }

        [Fact]
        public void Convert_EmptyInput() // Пустой ввод
        {
            var adapter = new Adapter();
            string input = "";

            Assert.Throws<ArgumentException>(() => adapter.Convert(input, 2, 10));
        }

        [Fact]
        public void Convert_InvalidBase() // Неверное основание
        {
            var adapter = new Adapter();

            Assert.Throws<ArgumentException>(() => adapter.Convert("101", 1, 17));
        }

        [Fact]
        public void Convert_MinusBinary() // Минусовое значение
        {
            var adapter = new Adapter();
            string input = "-1101";
            string expected = "-13";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_MaxLong10() // Граничное значение
        {
            var adapter = new Adapter();
            string input = "9223372036854775807";
            string expected = new string('1', 63);

            string actual = adapter.Convert(input, 10, 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_MaxLongBinary() // Максимальное значениеы
        {
            var adapter = new Adapter();
            string input = new string('1', 63);
            string expected = "9223372036854775807";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_64Binary() // Переполнение в ToBase10
        {
            var adapter = new Adapter();
            string input = new string('1', 64);
            string expected = "18446744073709551615";

            string actual = adapter.Convert(input, 2, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_FromBase10Overflow() // Ошибка в FromBase10
        {
            var adapter = new Adapter();
            string input = "18446744073709551615";
            string expected = new string('1', 64);

            string actual = adapter.Convert(input, 10, 2);

            Assert.Equal(expected, actual);
        }
    }
}
