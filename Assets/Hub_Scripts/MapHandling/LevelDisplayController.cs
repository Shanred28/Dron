using UnityEngine;

namespace Hacaton
{
    public class LevelDisplayController : MonoBehaviour
    {
        [SerializeField] private MapLevel[] m_MapLevels;
        private void Start()
        {

            m_MapLevels = GetComponentsInChildren<MapLevel>();
            int count = 0;
            MapLevel firstActive = null;
            for (int i = 0; i < m_MapLevels.Length; i++)
            {
                if (!m_MapLevels[i].Level.IsAddedToMap)
                {
                    m_MapLevels[i].gameObject.SetActive(false);
                    count++;
                }
                else if (!firstActive)
                {
                    firstActive = m_MapLevels[i];
                }
            }
            if (m_MapLevels.Length > count)
                LevelInfoUpdaterUI.Init(firstActive);
        }
    }
}

