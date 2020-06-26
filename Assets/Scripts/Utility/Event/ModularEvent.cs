using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.ModularFrameworks
{
    [CreateAssetMenu(fileName = "New Modular Event", menuName = "Modular Frameworks/Event System/Modular Event")]
    public class ModularEvent : ScriptableObject
    {
        #region DEBUG
            #if UNITY_EDITOR
                public List<string> eventListenersIdentity = new List<string>();
            #endif
        #endregion

        private readonly List<ModularEventListener> eventListeners = new List<ModularEventListener>();

        public void Raise ()
        {
            foreach(var e in eventListeners)
            {
                e.OnEventRaised();
            }
        }

        public void RegistListener (ModularEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                #region DEBUG
                    #if UNITY_EDITOR
                        eventListenersIdentity.Add(listener.name);
                    #endif
                #endregion

                eventListeners.Add(listener);
            }
        }

        public void UnregistListener (ModularEventListener listener)
        {
            if (eventListeners.Contains(listener))
            {
                #region DEBUG
                    #if UNITY_EDITOR
                        eventListenersIdentity.Remove(listener.name);
                    #endif
                #endregion

                eventListeners.Remove(listener);
            }
        }
    }
}
