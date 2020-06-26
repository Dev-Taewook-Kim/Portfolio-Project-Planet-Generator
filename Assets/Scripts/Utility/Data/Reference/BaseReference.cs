using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [System.Serializable]
    public abstract class BaseReference<T, U> where U : BaseVariable<T>
    {
        public bool useConstant = true;

        [SerializeField]
        private T constantValue;

        [SerializeField]
        private U Variable = null;

        public BaseReference () { }

        public BaseReference (T value)
        {
            useConstant = true;
            constantValue = value;
        }

        public T Value
        {
            get { return useConstant ? constantValue : Variable.value; }
            set { if (useConstant) constantValue = value; else Variable.value = value; }
        }
    }
}
