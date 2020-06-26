using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public class ReferenceDouble : BaseReference<double, VariableDouble>
    {
        public ReferenceDouble () : base () { }

        public ReferenceDouble (double value) : base (value) { }

        public static implicit operator string (ReferenceDouble Reference)
        {
            return Reference.Value.ToString();
        }

        public static implicit operator double (ReferenceDouble Reference)
        {
            return Reference.Value;
        }

        public static implicit operator ReferenceDouble (double value)
        {
            return new ReferenceDouble(value);
        }
    }
}
