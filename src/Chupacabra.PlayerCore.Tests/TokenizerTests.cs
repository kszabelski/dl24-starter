using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chupacabra.PlayerCore.Service;
using NUnit.Framework;

namespace Chupacabra.PlayerCore.Tests
{
    public class TokenizerTests
    {
        class LineReader : ILineReader
        {
            private readonly TextReader _reader;

            public LineReader(TextReader reader)
            {
                _reader = reader;
            }

            public string ReadLine()
            {
                return _reader.ReadLine();
            }
        }

        [Test]
        public void MultilineInputShouldBeTokenized()
        {
            var input = @"1 2 -1000 ala 2e4  2.1
 5             4   
1e4
";
            var reader = new LineReader(new StringReader(input));
            var tokenizer = new Tokenizer(reader);

            Assert.AreEqual(1, tokenizer.ReadInt());
            Assert.AreEqual(2, tokenizer.ReadDouble());
            Assert.AreEqual(-1000, tokenizer.ReadInt());
            Assert.AreEqual("ala", tokenizer.ReadString());
            Assert.AreEqual(2e4, tokenizer.ReadDouble());
            Assert.AreEqual(2.1, tokenizer.ReadDouble());
            Assert.AreEqual(5, tokenizer.ReadInt());
            Assert.AreEqual(4, tokenizer.ReadInt());
            Assert.AreEqual(1e4, tokenizer.ReadDouble());
        }
    }
}
