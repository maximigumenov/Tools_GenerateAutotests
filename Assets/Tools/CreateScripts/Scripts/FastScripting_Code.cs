using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace CreateScriptsSpace
{
    [System.Serializable]
    public class FastScripting_Code
    {
        public string path;

        [TextArea]
        public string usingMessage =
            "using System.Collections;\n" +
            "using System.Collections.Generic;\n" +
            "using UnityEngine;\n" +
            "\n";

        public string nameSpace;
        public string nameClass;
        public string nameBaseClass;
        [TextArea]
        public string bodyClass =
            "{\n" +
            "\n" +
            "}"

            ;

        public ContentForAutoCode contentForAutoCode;

        public void CreateCode()
        {
            ReplacingData();

            string[] usingText = Regex.Split(usingMessage, @"\n");
            string[] bodyText = Regex.Split(bodyClass, @"\n");

            string fileName = Application.dataPath + "/";

            if (!string.IsNullOrEmpty(path))
            {
                fileName += path + "/";
            }

            fileName += nameClass + ".cs";
            Debug.Log("Generated code by the path " + fileName);
            using (StreamWriter outfile =
                      new StreamWriter(fileName))
            {

                for (int i = 0; i < usingText.Length; i++)
                {
                    outfile.WriteLine(usingText[i]);
                }

                string _name = "public class " + nameClass;

                if (!string.IsNullOrEmpty(nameBaseClass))
                {
                    _name += " : " + nameBaseClass;
                }

                if (!string.IsNullOrEmpty(nameSpace))
                {
                    outfile.WriteLine("namespace " + nameSpace);
                    outfile.WriteLine("{");
                }

                outfile.WriteLine(_name);
                
                for (int i = 0; i < bodyText.Length; i++)
                {
                    outfile.WriteLine(bodyText[i]);
                }

                if (!string.IsNullOrEmpty(nameSpace))
                {
                    outfile.WriteLine("}");
                }



            }//File written
        }

        private void ReplacingData()
        {
            if (contentForAutoCode != null)
            {
                if (!string.IsNullOrEmpty(contentForAutoCode.path))
                {
                    path = contentForAutoCode.path;
                }

                if (!string.IsNullOrEmpty(contentForAutoCode.usingMessage))
                {
                    usingMessage = contentForAutoCode.usingMessage;
                }

                if (!string.IsNullOrEmpty(contentForAutoCode.nameSpace))
                {
                    nameSpace = contentForAutoCode.nameSpace;
                }

                if (!string.IsNullOrEmpty(contentForAutoCode.nameClass))
                {
                    nameClass = contentForAutoCode.nameClass;
                }

                if (!string.IsNullOrEmpty(contentForAutoCode.nameBaseClass))
                {
                    nameBaseClass = contentForAutoCode.nameBaseClass;
                }

                if (!string.IsNullOrEmpty(contentForAutoCode.bodyClass))
                {
                    bodyClass = contentForAutoCode.bodyClass;
                }
            }
        }
    }
}
