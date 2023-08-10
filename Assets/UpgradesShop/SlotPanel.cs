using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Hacaton
{
    public abstract class SlotPanel<T, V> : MonoBehaviour where T : ScriptableObject where V : Slot<T>
    {
        [SerializeField] protected T[] m_SlotObjects;
        private List<V> m_Adverts;
        public UnityEvent NoAdvertsLeft;
        

        protected virtual void Awake()
        {
            m_Adverts = new List<V>(GetComponentsInChildren<V>());
        }

        protected virtual void Start()
        {
            FillAdverts();
        }

        protected virtual void FillAdverts()
        {
            if (m_SlotObjects.Length == 0)
            {
                NoAdvertsLeft.Invoke();
                return;
            }
            for (int i = 0; i < m_Adverts.Count; i++)
            {
                if (i < m_SlotObjects.Length)
                {
                    if (!m_Adverts[i].gameObject.activeSelf)
                        m_Adverts[i].gameObject.SetActive(true);
                    var advert = m_Adverts[i];
                    advert.Initialize(m_SlotObjects[i]);
                    advert.OnUserInteraction += OnUserAdvertsInteraction;
                }
                else if (m_Adverts[i].gameObject.activeSelf)
                {
                    m_Adverts[i].gameObject.SetActive(false);
                }
            }
        }

        protected virtual void OnUserAdvertsInteraction(Slot<T> advert)
        {
            (advert as V).OnUserInteraction -= OnUserAdvertsInteraction;
            //OnUserInteractedWithSlot?.Invoke(advert.CurrentOccupant);
            FillAdverts();
        }
    }
}

