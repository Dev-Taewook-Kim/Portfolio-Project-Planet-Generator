using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceVector2 : BaseReference<Vector2, VariableVector2>
    {
        public ReferenceVector2 () : base() { }

        public ReferenceVector2 (Vector2 value) : base(value) { }

        public static implicit operator string(ReferenceVector2 Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator Vector2(ReferenceVector2 Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceVector2(Vector2 value)
        {
            return new ReferenceVector2(value);
        }
    }
}
