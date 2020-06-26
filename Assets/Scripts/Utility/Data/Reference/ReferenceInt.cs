using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceInt : BaseReference<int, VariableInt>
    {
        public ReferenceInt () : base() { }

        public ReferenceInt (int value) : base (value) { }

        public static implicit operator string (ReferenceInt Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator int (ReferenceInt Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceInt (int value)
        {
            return new ReferenceInt(value);
        }
    }
}
