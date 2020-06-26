using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceBool : BaseReference<bool, VariableBool>
    {
        public ReferenceBool() : base() { }

        public ReferenceBool(bool value) : base(value) { }

        public static implicit operator string(ReferenceBool Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator bool(ReferenceBool Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceBool(bool value)
        {
            return new ReferenceBool(value);
        }
    }
}
