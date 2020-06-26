using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    public abstract class BaseVariable<T> : ScriptableObject
    {
        [Multiline]
        public string comment;

        public T value;
    }
}
