using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace kextool
{
    class Program
    {
        static void Main(string[] args)
        {
            readBinFile();
        }

        static void readBinFile()
        {
            using (BinaryReader reader = new BinaryReader(File.Open("ammo_shellbox01.bin", FileMode.Open)))
            {
                int length = (int)reader.BaseStream.Length;
                int pos = 0;
       
                while (pos < length)
                {
                    int version = reader.ReadInt32();
                    Console.WriteLine("Version: " + version);
                    pos += sizeof(int);

                    Vector3 boundingBoxMin = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    Console.WriteLine("Bounding Box Min: " + boundingBoxMin);
                    pos += sizeof(float);
                    pos += sizeof(float);
                    pos += sizeof(float);

                    Vector3 boundingBoxMax = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    Console.WriteLine("Bounding Box Max: " + boundingBoxMax);
                    pos += sizeof(float);
                    pos += sizeof(float);
                    pos += sizeof(float);
                    Console.Read();
                }
            }
        } 
    }
}
