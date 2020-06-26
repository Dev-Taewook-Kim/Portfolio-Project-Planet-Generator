using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceVector4 : BaseReference<Vector4, VariableVector4>
    {
        public ReferenceVector4 () : base () { }

        public ReferenceVector4 (Vector4 value) : base (value) { }

        public static implicit operator string (ReferenceVector4 Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator Vector4 (ReferenceVector4 Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceVector4 (Vector4 value)
        {
            return new ReferenceVector4(value);
        }
    }
}
