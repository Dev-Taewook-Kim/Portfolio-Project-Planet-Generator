using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceByte : BaseReference<byte, VariableByte>
    {
        public ReferenceByte () : base () { }

        public ReferenceByte (byte value) : base (value) { }

        public static implicit operator string (ReferenceByte Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator byte (ReferenceByte Reference)
        {
            return Reference.Value;
        }

        public static implicit  operator ReferenceByte (byte value)
        {
            return new ReferenceByte(value);
        }
    }
}
