using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceString : BaseReference<string, VariableString>
    {
        public ReferenceString () : base() { }

        public ReferenceString (string value) : base(value) { }

        public static implicit operator string(ReferenceString Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceString(string value)
        {
            return new ReferenceString(value);
        }
    }
}
