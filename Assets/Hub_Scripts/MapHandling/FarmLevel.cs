using UnityEngine;

namespace Hacaton
{
    [CreateAssetMenu(menuName ="Levels/FarmLevel")]
    public class FarmLevel : Level
    {
        [SerializeField] private Level m_RootLevel;

        [SerializeField] private bool m_IsRejected = false;
        public bool IsRejected()
        {
            return m_IsRejected;
        }
        public void SetRejected(bool isRejected)
        {
            m_IsRejected = isRejected;
        }
     
        public override bool IsAvailable()
        {
            if (m_RootLevel == null)
                m_IsAvailable = !m_IsRejected && !IsAddedToMap;
            else
                m_IsAvailable = !m_IsRejected && m_RootLevel.IsCompleted && !IsAddedToMap;
            return m_IsAvailable;
        }
    }
}

