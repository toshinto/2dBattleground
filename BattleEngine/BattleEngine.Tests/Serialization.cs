using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine.Tests
{
    [TestClass]
    public class Serialization
    {
        [TestMethod] public void TestProjectileSerialization()
        {
            var m = new Map();
            var inObject = new GameObject(m)
            {
                Position = new Vector(5, 6),
            };
            byte[] Buffer;
            using (var ms = new MemoryStream())
            {
                using (var w = new BinaryWriter(ms))
                    inObject.Serialize(w);

                Buffer = ms.ToArray();
            }

            Assert.AreNotEqual(Buffer.Length, 0);

            var outObject = new GameObject(m);

            using (var ms = new MemoryStream(Buffer))
            using (var s = new BinaryReader(ms))
            {
                outObject.DeSerialize(s);
            }

            Assert.AreEqual(outObject.Position.X, 5);
            Assert.AreEqual(outObject.Position.Y, 6);


        }
    }
}
