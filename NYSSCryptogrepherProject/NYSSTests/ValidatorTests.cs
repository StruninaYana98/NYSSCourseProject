using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NYSSCryptographer;

namespace NYSSTests
{
   
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void FileNameValidator_HasForbiddenSymbols_false()
        {
            bool actual = Validator.FileNameValidator("file;name!");
            Assert.IsTrue(actual == false);

        }
        [TestMethod]
        public void FileNameValidator_NoForbiddenSymbols_true()
        {
            bool actual = Validator.FileNameValidator("имя файла");
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void PathValidator_PathWithoutSlash_SlashAdded()
        {
            string teststring = "folder1\\folder2";
            string expected = "folder1\\folder2\\";
            string actual = Validator.PathValidator(teststring);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void PathValidator_PathWithSlash_SamePath()
        {
            string teststring = "folder1\\folder2\\";
            string expected = "folder1\\folder2\\";
            string actual = Validator.PathValidator(teststring);

            Assert.AreEqual(expected, actual);

        }
    }
}
