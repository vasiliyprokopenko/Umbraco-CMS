﻿using System;
using System.IO;
using System.Xml;
using NUnit.Framework;
using Umbraco.Tests.TestHelpers;

namespace Umbraco.Tests.Configurations
{

    [TestFixture]
    public class LanguageXmlTests
    {
        [Test]
        public void Can_Load_Language_Xml_Files()
        {
            var dir = new DirectoryInfo(TestHelper.MapPathForTest("~/"));
            if (dir == null)
                throw new NullReferenceException("dir is null. | " + dir.FullName);
            while (dir.Name != "src")
            {
                dir = dir.Parent;
                if (dir == null)
                    throw new NullReferenceException("dir is null - 2 | " + dir.FullName);
            }
            var languageDirectory = new DirectoryInfo(dir.FullName + "/Umbraco.Web.UI/Umbraco/config/lang/");
            var readFilesCount = 0;
            var xmlDocument = new XmlDocument();
            foreach (var languageFile in languageDirectory.EnumerateFiles("*.xml"))
            {
                // load will throw an exception if the xml isn't valid.
                xmlDocument.Load(languageFile.FullName);
                readFilesCount++;
            }
            // ensure that at least one file was read.
            Assert.AreNotEqual(0, readFilesCount);
        }
    }
}
