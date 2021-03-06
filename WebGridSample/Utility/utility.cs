﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGridSample.Models;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Text;

namespace WebGridSample.Utility
{
    public static class utility
    {
        public static string ToXml<T>(this T obj, string rootName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var xmlNs = new XmlSerializerNamespaces();
            xmlNs.Add(string.Empty, string.Empty);

            using (StringWriter sw = new Utf8StringWriter())
            {
                serializer.Serialize(sw, obj, xmlNs);
                return sw.ToString();
            }
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
        //public override Encoding Encoding = Encoding.UTF8;
    }
}