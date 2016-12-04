using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace INVedit.XML
{
    /// <summary>
    /// Class for loading data.xml
    /// </summary>
    static class XMLReader
    {
        private static XmlTextReader sReader;

        private static bool sIsReady = false;

        public static void sInit(string _filename)
        {
            sReader = new XmlTextReader(_filename);
            sIsReady = true;
        }

        public static void sInit(Stream _filestream)
        {
            sReader = new XmlTextReader(_filestream);
            sIsReady = true;
        }

        public static void sClear()
        {
            sReader = null;
            sIsReady = false;
        }

        public static bool sCheckIfReady(bool _throwException = true)
        {
            if (sIsReady)
            {
                return true;
            }
            else
            {
                if (_throwException) { throw new XmlDataException("The XMLReader is not ready! Please load a file first!"); }
                return false;
            }
        }

        public static bool sPrepareNextNode()
        {
            sCheckIfReady();
            return sReader.Read();
        }

        public static XmlNodeType sGetType()
        {
            sCheckIfReady();
            return sReader.NodeType;
        }

        public static string sGetPos()
        {
            sCheckIfReady();
            return String.Concat("line: ", sReader.LineNumber, ", pos: ", sReader.LinePosition);
        }

        public static string sGetName()
        {
            sCheckIfReady();
            return sReader.Name;
        }

        public static bool sCheckElement(string _name)
        {
            sCheckIfReady();
            return sReader.NodeType == XmlNodeType.Element && sReader.Name.Equals(_name);
        }

        public static string sReadNextString()
        {
            sCheckIfReady();
            sReader.Read();
            sReader.MoveToContent();
            return sReader.ReadElementContentAsString();
        }

        public static string[] sReadNextStringArray(char _separator, bool _ignoreEmptyEntries = true)
        {
            sCheckIfReady();
            sReader.Read();
            sReader.MoveToContent();

            string s = sReader.ReadElementContentAsString();
            /*if (s.Contains(_separator))
            {*/
            return s.Split(new char[] { _separator }, (_ignoreEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None));
            /*}
            else
            {
                throw new Exception("Could not parse string array: Node doesn't contain separator char");
            }*/
        }

        public static float sReadNextFloat()
        {
            sCheckIfReady();
            sReader.Read();
            sReader.MoveToContent();
            return sReader.ReadElementContentAsFloat();
        }

        public static int sReadNextInt()
        {
            sCheckIfReady();
            sReader.Read();
            sReader.MoveToContent();
            return sReader.ReadElementContentAsInt();
        }

        public static double sReadNextDouble()
        {
            sCheckIfReady();
            sReader.Read();
            sReader.MoveToContent();
            return sReader.ReadElementContentAsDouble();
        }

        public static short sReadNextShort()
        {
            sCheckIfReady();
            sReader.Read();
            sReader.MoveToContent();
            return short.Parse(sReader.ReadElementContentAsString());
        }

        public static byte sReadNextByte()
        {
            sCheckIfReady();
            sReader.Read();
            sReader.MoveToContent();
            return byte.Parse(sReader.ReadElementContentAsString());
        }
    }
    public class XmlDataException : Exception
    {
        public XmlDataException() : base() { }
        public XmlDataException(string message) : base(message) { }
        public XmlDataException(string message, Exception innerException) : base(message, innerException) { }
    }
}
