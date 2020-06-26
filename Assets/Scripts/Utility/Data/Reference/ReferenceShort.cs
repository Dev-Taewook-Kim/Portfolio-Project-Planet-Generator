using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceShort : BaseReference<short, VariableShort>
    {
        public ReferenceShort () : base() { }

        public ReferenceShort (short value) : base(value) { }

        public static implicit operator string(ReferenceShort Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator short(ReferenceShort Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceShort(short value)
        {
            return new ReferenceShort(value);
        }
    }
}
