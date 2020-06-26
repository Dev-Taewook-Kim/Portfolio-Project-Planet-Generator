using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceUlong : BaseReference<ulong, VariableUlong>
    {
        public ReferenceUlong () : base() { }

        public ReferenceUlong (ulong value) : base(value) { }

        public static implicit operator string(ReferenceUlong Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator ulong(ReferenceUlong Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceUlong(ulong value)
        {
            return new ReferenceUlong(value);
        }
    }
}
