using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceFloat : BaseReference<float, VariableFloat>
    {
        public ReferenceFloat () : base () { }

        public ReferenceFloat (float value) : base (value) { }

        public static implicit operator string (ReferenceFloat Reference)
        {
            return Reference.Value.ToString();
        } 

        public static implicit operator float (ReferenceFloat Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceFloat (float value)
        {
            return new ReferenceFloat(value);
        }
    }
}
