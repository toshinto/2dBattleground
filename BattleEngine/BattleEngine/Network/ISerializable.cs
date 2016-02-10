using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine.Network
{
    interface ISerializable
    {
        void Serialize(BinaryWriter writer);

        void Deserialize(BinaryReader reader);
    }
}
