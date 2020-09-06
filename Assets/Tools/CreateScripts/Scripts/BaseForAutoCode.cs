using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScriptsSpace
{
    public class BaseForAutoCode : MonoBehaviour
    {
        public FastScripting_Code code;

        public virtual void Call()
        {
            code.CreateCode();
        }
    }
}
