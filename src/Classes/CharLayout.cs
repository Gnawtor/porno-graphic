﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Porno_Graphic.Classes
{
    [Serializable()]
    [XmlRoot(ElementName = "layout", Namespace = "http://romhackers.net/porno-graphic/profile")]
    public class CharLayout
    {
        [Serializable()]
        public class Offset
        {
            [XmlAttribute("bits")]
            public uint Bits { get; set; }

            [XmlAttribute("fracnum")]
            public uint FractionNumerator { get; set; }

            [XmlAttribute("fracden")]
            public uint FractionDenominator { get; set; }

            public Offset()
            {
                FractionNumerator = 0U;
                FractionDenominator = 1U;
            }
        };

        [Serializable()]
        public class OffsetList
        {
            [XmlAttribute("multiplier")]
            public uint Multiplier { get; set; }

            [XmlAttribute("duplicator")]
            public uint Duplicator { get; set; }

            [XmlElement(ElementName = "offset", Form = XmlSchemaForm.Unqualified)]
            public Offset[] Offsets { get; set; }

            public uint Offset(uint length, uint index) { return (Offsets[index].Bits * Multiplier) + (8 * length * Offsets[index].FractionNumerator / Offsets[index].FractionDenominator); }

            public uint MaxOffset(uint length)
            {
                uint result = 0U;
                for (uint i = 0; i < Offsets.Length; i++)
                    result = Math.Max(result, Offset(length, i));
                return result;
            }

            public OffsetList()
            {
                Multiplier = 1U;
                Duplicator = 0U;
            }
        };

        [XmlElement(ElementName = "plane", Form = XmlSchemaForm.Unqualified)]
        public OffsetList Plane { get; set; }

        [XmlElement(ElementName = "x", Form = XmlSchemaForm.Unqualified)]
        public OffsetList X { get; set; }

        [XmlElement(ElementName = "y", Form = XmlSchemaForm.Unqualified)]
        public OffsetList Y { get; set; }

        [XmlAttribute("name")]
        public String Name { get; set; }

        [XmlElement(ElementName = "stride", Form = XmlSchemaForm.Unqualified)]
        public uint Stride { get; set; }

        public uint Planes { get { return (uint)Plane.Offsets.Length; } }
        public uint Width { get { return (uint)X.Offsets.Length; } }
        public uint Height { get { return (uint)Y.Offsets.Length; } }

        public uint PlaneOffset(byte[] data, uint index) { return Plane.Offset((uint)data.Length, index); }
        public uint XOffset(byte[] data, uint index) { return X.Offset((uint)data.Length, index); }
        public uint YOffset(byte[] data, uint index) { return Y.Offset((uint)data.Length, index); }
        public uint MaxOffset(uint length, uint index) { return (Stride * index) + Plane.MaxOffset(length) + X.MaxOffset(length) + Y.MaxOffset(length); }
        public uint Duplicator() { return (Plane.Duplicator ); }

        public uint MaxElements(uint length, uint offset)
        {
            if (length < offset)
                return 0U;
            uint availableBits = (length - offset) * 8U;
            uint elementBits = MaxOffset(length, 0U) + 1;
            if (elementBits > (availableBits + Stride))
                return 0U;
            else
                return (availableBits + Stride - elementBits) / Stride;
        }
    }
}
