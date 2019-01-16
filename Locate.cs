using System;

namespace Photon.Hive.Plugin.SHProject
{
    [Serializable]
    public struct Locate
    {
        public short x { get; set; }
        public short z { get; set; }

        public Locate(short x, short z)
        {
            this.x = x;
            this.z = z;
        }

        public static object Deserialize(byte[] data)
        {
            var result = new Locate();
            result.x = data[0];
            result.z = data[1];
            return result;
        }

        public static byte[] Serialize(object customType)
        {
            var c = (Locate)customType;
            return new byte[] { (byte)c.x, (byte)c.z };
        }
    }

    public static class RandomLocate
    {
        private static Random rnd = new Random();
        public static Locate GetRandomLocate()
        {
            return new Locate((short)rnd.Next(25), (short)rnd.Next(25));
        }
    }
}
