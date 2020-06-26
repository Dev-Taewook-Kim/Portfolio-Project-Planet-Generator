using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceLong : BaseReference<long, VariableLong>
    {
        public ReferenceLong () : base () { }

        public ReferenceLong (long value) : base (value) { }

        public static implicit operator string (ReferenceLong Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator long (ReferenceLong Reference)
        {
            return Reference.Value;
        }
        
        public static implicit operator ReferenceLong (long value)
        {
            return new ReferenceLong(value);
        }
    }
}
