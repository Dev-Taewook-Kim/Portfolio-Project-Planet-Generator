using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceChar : BaseReference<char, VariableChar>
    {
        public ReferenceChar () : base () { }

        public ReferenceChar (char value) : base (value) { }

        public static implicit operator string (ReferenceChar Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator char (ReferenceChar Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceChar (char value)
        {
            return new ReferenceChar(value);
        }
    }
}
