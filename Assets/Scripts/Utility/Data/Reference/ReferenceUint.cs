using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceUint : BaseReference<uint, VariableUint>
    {
        public ReferenceUint() : base() { }

        public ReferenceUint(uint value) : base(value) { }

        public static implicit operator string(ReferenceUint Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator uint(ReferenceUint Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceUint(uint value)
        {
            return new ReferenceUint(value);
        }
    }
}
