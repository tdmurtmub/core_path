using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorePath.MSTest
{
    using tdmm.FileSystem;

    [TestClass]
    public class CorePathTestClass

    {
        [TestMethod]
        public void ConstructorKeepsSnapshotOfArguments()
        {
            var arg = new [] { "A", "B", "C"};
            var uut = new CorePath(arg);
            arg[1] = "Z";
            Assert.AreEqual(@"A\B\C", uut.ToString());
        }

        [TestMethod]
        public void ValidSegmentName()
        {
            var validSegmentName = new CorePath("ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz-0123456789.");
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz-0123456789.", validSegmentName.ToString());
        }

        // TODO [WES] Limit each segment length to 255 chars (LCD for Windows, Linux, Android).
        [TestMethod]
        public void SegmentNameLengthLimit()
        {
            Assert.ThrowsException<ArgumentException>(delegate { new CorePath(new String('A', CorePath.MaxLength + 1)); });
        }

        [TestMethod]
        public void InvalidCharactersInSegmentNames()
        {
            Assert.ThrowsException<CorePath.SegmentNameException>(delegate { new CorePath(""); }, "Empty string.");
            Assert.ThrowsException<CorePath.SegmentNameException>(delegate { new CorePath("$not_valid$"); });
            Assert.ThrowsException<CorePath.SegmentNameException>(delegate { new CorePath("valid", "$not_valid$"); });
        }

        [TestMethod]
        public void PathToString()
        {
            Assert.AreEqual("S1", new CorePath("S1").ToString());
            Assert.AreEqual(@"S1\S2", new CorePath("S1", "S2").ToString());
            Assert.AreEqual(@"S1\S2\S3", new CorePath("S1", "S2", "S3").ToString());
        }

        [TestMethod]
        public void TotalPathLengthIsLimitedToLCD()
        {
            var arg = new[]
            {
                new String('A', CorePath.MaxLength - 10),
                "1234567890"
            };
            Assert.ThrowsException<ArgumentException>(delegate { new CorePath(arg); }, "Limit total path length to the LCD for Windows, Linux and Android.");
        }
    }
}