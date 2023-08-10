using System;
using UnityEngine;

namespace Hacaton
{
    public abstract class Slot<T> : MonoBehaviour
    {
        public Action<Slot<T>> OnUserInteraction;
        protected T m_CurrentOccupant;
        public T CurrentOccupant => m_CurrentOccupant;
        public abstract void Initialize(T slotableObject);
    }
}

