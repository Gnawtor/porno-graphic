﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Porno_Graphic.Classes
{
    [Serializable()]
    [XmlRoot(ElementName = "region", Namespace = "http://romhackers.net/porno-graphic/profile")]
    public class LoadRegion
    {
        public enum Lanes
        {
            [XmlEnum("8/byte")]
            ByteByte,
            [XmlEnum("16/byte")]
            WordByte,
            [XmlEnum("16/word")]
            WordWord,
            [XmlEnum("32/byte")]
            DWordByte,
            [XmlEnum("32/word")]
            DWordWord,
            [XmlEnum("32/dword")]
            DWordDWord,
            [XmlEnum("64/byte")]
            QWordByte,
            [XmlEnum("64/word")]
            QWordWord,
            [XmlEnum("64/dword")]
            QWordDWord,
            [XmlEnum("64/qword")]
            QWordQWord
        }

        public class Instruction
        {
            [XmlIgnore]
            public uint Offset { get; set; }

            [XmlIgnore]
            public uint Size { get; set; }

            [XmlAttribute("offset")]
            public string SerializedOffset
            {
                get { return Offset.ToString("x"); }
                set { Offset = uint.Parse(value, NumberStyles.HexNumber); }
            }

            [XmlAttribute("size")]
            public string SerializedSize
            {
                get { return Size.ToString("x"); }
                set { Size = uint.Parse(value, NumberStyles.HexNumber); }
            }
        };

        public abstract class LoadLanes
        {

            [XmlIgnore]
            public uint Group { get; private set; }

            [XmlIgnore]
            public uint Skip { get; private set; }

            [XmlAttribute("lanes")]
            public Lanes SerializedLanes
            {
                set
                {
                    switch (value)
                    {
                        case Lanes.ByteByte:
                            Group = 1U;
                            Skip = 0U;
                            break;
                        case Lanes.WordByte:
                            Group = 1U;
                            Skip = 1U;
                            break;
                        case Lanes.WordWord:
                            Group = 2U;
                            Skip = 0U;
                            break;
                        case Lanes.DWordByte:
                            Group = 1U;
                            Skip = 3U;
                            break;
                        case Lanes.DWordWord:
                            Group = 2U;
                            Skip = 2U;
                            break;
                        case Lanes.DWordDWord:
                            Group = 4U;
                            Skip = 0U;
                            break;
                        case Lanes.QWordByte:
                            Group = 1U;
                            Skip = 7U;
                            break;
                        case Lanes.QWordWord:
                            Group = 2U;
                            Skip = 6U;
                            break;
                        case Lanes.QWordDWord:
                            Group = 4U;
                            Skip = 4U;
                            break;
                        case Lanes.QWordQWord:
                            Group = 8U;
                            Skip = 0U;
                            break;
                    }
                }
                get
                {
                    switch (Group)
                    {
                        case 1U:
                            switch (Skip)
                            {
                                case 0U:
                                    return Lanes.ByteByte;
                                case 1U:
                                    return Lanes.WordByte;
                                case 3U:
                                    return Lanes.DWordByte;
                                case 7U:
                                    return Lanes.QWordByte;
                            }
                            break;
                        case 2U:
                            switch (Skip)
                            {
                                case 0U:
                                    return Lanes.WordWord;
                                case 2U:
                                    return Lanes.DWordWord;
                                case 6U:
                                    return Lanes.QWordWord;
                            }
                            break;
                        case 4U:
                            switch (Skip)
                            {
                                case 0U:
                                    return Lanes.DWordDWord;
                                case 4U:
                                    return Lanes.QWordDWord;
                            }
                            break;
                        case 8U:
                            switch (Skip)
                            {
                                case 0U:
                                    return Lanes.QWordQWord;
                            }
                            break;
                    }
                    throw new ArgumentOutOfRangeException();
                }
            }

            public LoadLanes()
            {
                Group = 1U;
                Skip = 0U;
            }
        };

        public class File : LoadLanes
        {
            [XmlAttribute("name")]
            public String Name { get; set; }

            [XmlAttribute("byteswap")]
            public bool ByteSwap { get; set; }

            [XmlElement(ElementName = "load", Form = XmlSchemaForm.Unqualified)]
            public Instruction[] Instructions { get; set; }

            public uint SwapMask { get { return ByteSwap ? (Group - 1U) : 0U; } }

            public uint LoadedLength
            {
                get
                {
                    uint result = 0;
                    foreach (Instruction instruction in Instructions)
                        result += instruction.Size;
                    return result;
                }
            }

            public File()
            {
                ByteSwap = false;
            }
        };

        public class Fill : LoadLanes
        {
            [XmlIgnore]
            public uint Offset { get; set; }

            [XmlIgnore]
            public uint Size { get; set; }

            [XmlIgnore]
            public byte Value { get; set; }

            [XmlAttribute("offset")]
            public string SerializedOffset
            {
                get { return Offset.ToString("x"); }
                set { Offset = uint.Parse(value, NumberStyles.HexNumber); }
            }

            [XmlAttribute("size")]
            public string SerializedSize
            {
                get { return Size.ToString("x"); }
                set { Size = uint.Parse(value, NumberStyles.HexNumber); }
            }

            [XmlAttribute("value")]
            public string SerializedValue
            {
                get { return Value.ToString("x2"); }
                set { Value = byte.Parse(value, NumberStyles.HexNumber); }
            }
        };

        [XmlAttribute("name")]
        public String Name { get; set; }

        [XmlIgnore]
        public uint Length { get; set; }

        [XmlIgnore]
        public bool Erase { get; set; } // for erase regions in mame where there are empty gaps in memory between files (ie, ROMREGION_ERASEFF) (see Blocken game definition in shangha3 for an example)

        [XmlIgnore]
        public byte EraseValue { get; set; }

        [XmlAttribute("invert")]
        public bool Invert { get; set; }

        [XmlElement(ElementName = "file", Form = XmlSchemaForm.Unqualified)]
        public File[] Files { get; set; }

        [XmlElement(ElementName = "fill", Form = XmlSchemaForm.Unqualified)]
        public Fill[] Fills { get; set; }

        [XmlAttribute("length")]
        public string SerializedLength
        {
            get { return Length.ToString("x"); }
            set { Length = uint.Parse(value, NumberStyles.HexNumber); }
        }

        [XmlAttribute("erase")]
        public string SerializedEraseValue
        {
            get
            {
                return Erase ? EraseValue.ToString("x2") : null;
            }
            set
            {
                if (value != null)
                {
                    EraseValue = byte.Parse(value, NumberStyles.HexNumber);
                    Erase = true;
                }
                else
                {
                    Erase = false;
                }
            }
        }

        public LoadRegion()
        {
            Erase = false;
            Invert = false;
        }

        public byte[] LoadFiles(string[] paths)
        {
            byte[] result = new byte[Length];
            if (Erase)
            {
                for (uint i = 0; i < Length; i++)
                    result[i] = EraseValue;
            }
            byte[] buffer = null;
            for (int i = 0; i < Files.Length; i++)
            {
                File file = Files[i];   // file names defined in the profile
                FileStream stream = new FileStream(paths[i], FileMode.Open, FileAccess.Read); 
                try
                {
                    uint maxSize = 0;
                    foreach (Instruction instruction in file.Instructions)
                        maxSize = Math.Max(maxSize, instruction.Size);
                    if ((buffer == null) || (buffer.Length < maxSize))
                        buffer = new byte[maxSize];
                    for (int j = 0; j < file.Instructions.Length; j++)
                    {
                        Instruction instruction = file.Instructions[j];
                        int read = stream.Read(buffer, 0, (int)instruction.Size);
                        if (read < instruction.Size)
                            throw new LoadPastEndOfFileException(file, j, read);
                        uint destination = instruction.Offset;
                        for (uint source = 0; source < instruction.Size; source++)
                        {
                            uint offset = destination ^ file.SwapMask;
                            if (offset >= Length)
                                throw new LoadOutsideRegionException(this, i, offset);
                            result[offset] = buffer[source];
                            destination++;
                            if ((source % file.Group) == (file.Group - 1))
                                destination += file.Skip;
                        }
                    }
                }
                finally
                {
                    stream.Close();
                }
            }
            if (Fills != null)
            {
                for (int i = 0; i < Fills.Length; i++)
                {
                    Fill fill = Fills[i];
                    uint destination = fill.Offset;
                    for (uint source = 0; source < fill.Size; source++)
                    {
                        if (destination >= Length)
                            throw new FillOutsideRegionException(this, i, destination);
                        result[destination] = fill.Value;
                        destination++;
                        if ((source % fill.Group) == (fill.Group - 1))
                            destination += fill.Skip;
                    }
                }
            }
            if (Invert)
            {
                for (uint i = 0; i < Length; i++)
                    result[i] = (byte)~result[i];
            }
            return result;
        }

        public void SaveFiles(byte[] data, string[] paths)
        {
            for (int i = 0; i < Files.Length; i++)
            {
                File file = Files[i];
                
                byte[] saveData = null;

                FileStream stream = new FileStream(paths[i], FileMode.OpenOrCreate, FileAccess.Write);
                try
                {
                    uint fileSize = 0;
                    foreach (Instruction instruction in file.Instructions)
                        fileSize += instruction.Size;
                    if (saveData == null || saveData.Length < fileSize)
                        saveData = new byte[fileSize];

                    for (int j = 0; j < file.Instructions.Length; j++)
                    {
                        Instruction instruction = file.Instructions[j];
                        uint source = instruction.Offset;

                        for (uint dest = 0; dest < instruction.Size; dest++)
                        {
                            uint offset = source ^ file.SwapMask;
                            if (offset >= Length)
                                throw new LoadOutsideRegionException(this, i, offset);
                            saveData[dest] = data[offset];
                            source++;
                            if ((dest % file.Group) == (file.Group - 1))
                                source += file.Skip;
                        }
                    }

                    if (Invert)
                    {
                        for (uint k = 0; k < Length; k++)
                            saveData[k] = (byte)~saveData[k];
                    }

                    stream.Write(saveData, 0, saveData.Length);
                }
                finally
                {
                    stream.Close();
                }
            }
        }
    }
}
