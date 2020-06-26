using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace P2Playworks.ModularFrameworks
{
    public class ModularEventListener : MonoBehaviour
    {
        public ModularEvent modularEvent;

        public UnityEvent response;

        private void OnEnable()
        {
            modularEvent.RegistListener(this);
        }

        private void OnDisable()
        {
            modularEvent.UnregistListener(this);
        }

        public void OnEventRaised ()
        {
            response.Invoke();
        }
    }
}