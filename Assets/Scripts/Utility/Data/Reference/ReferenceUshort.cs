using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceUshort : BaseReference<ushort, VariableUshort>
    {
        public ReferenceUshort () : base() { }

        public ReferenceUshort (ushort value) : base(value) { }

        public static implicit operator string(ReferenceUshort Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator ushort(ReferenceUshort Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceUshort(ushort value)
        {
            return new ReferenceUshort(value);
        }
    }
}
