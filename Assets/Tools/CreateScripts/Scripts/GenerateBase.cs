using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScriptsSpace
{
    public class GenerateBase : BaseForAutoCode
    {
        public override void Call()
        {
            ContentForAutoCode content = new ContentForAutoCode();
            code.contentForAutoCode = content;
            content.nameSpace = "ExampleData";
            base.Call();
        }
    }
}
