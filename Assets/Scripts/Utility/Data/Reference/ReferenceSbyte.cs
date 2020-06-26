using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceSbyte : BaseReference<sbyte, VariableSbyte>
    {
        public ReferenceSbyte () : base () { }

        public ReferenceSbyte (sbyte value) : base (value) { }

        public static implicit operator string (ReferenceSbyte Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator sbyte (ReferenceSbyte Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceSbyte (sbyte value)
        {
            return new ReferenceSbyte(value);
        }
    }
}
