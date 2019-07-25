using NoteCore.Text;
using System;
using Xunit;

namespace NoteTest
{
    [Collection("NoteCore")]
    public class NoteTest
    {
        [Fact(DisplayName = "π˝¬À≈≈∞Ê∑˚")]
        public void TestStringTrimAll()
        {
            Assert.Equal("123456", "  123\t 4 \r\n 5 \r\n 6 \t ".TrimAll());
        }

        [Fact(DisplayName ="Unicode≤‚ ‘")]
        public void TestUnicode()
        {
        }
    }
}
