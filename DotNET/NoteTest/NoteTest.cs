using NoteCore.Text;
using System;
using Xunit;

namespace NoteTest
{
    [Collection("NoteCore")]
    public class NoteTest
    {
        [Fact(DisplayName = "StringUtil")]
        public void TestStringUtil()
        {
            Assert.Equal("123456", StringUtil.FilterSpace("  123\t 4 \r\n 5 \r\n 6 \t "));
        }

        public void TestUnicode()
        {

        }
    }
}
