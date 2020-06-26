using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceVector3 : BaseReference<Vector3, VariableVector3>
    {
        public ReferenceVector3 () : base () { }

        public ReferenceVector3 (Vector3 value) : base (value) { }

        public static implicit operator string (ReferenceVector3 Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator Vector3 (ReferenceVector3 Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceVector3 (Vector3 value)
        {
            return new ReferenceVector3(value);
        }
    }
}