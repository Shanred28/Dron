using System;
using UnityEngine;

namespace Hacaton
{
    public class MapLevel : MonoBehaviour
    {
        [SerializeField] private Level m_Level;
        //[SerializeField] private GameObject m_LevelTrackingCam;
        
        public Episode LevelEpisode => m_Level.Episode;
        public Level Level => m_Level;

        public bool IsCompleted => m_Level.IsCompleted;
        //private int m_Score = 0;
        public static event Action<MapLevel> LevelSelected;

        public void LoadLevel()
        {
            if (!m_Level.Episode) return;
            LevelSequenceController.Instance.StartMission(m_Level.Episode);
        }

        public int Initialize()
        {
            return 0;
        }

        public void SwitchCam(bool state)
        {
            //m_LevelTrackingCam.SetActive(state);
        }

        public void InvokeSelectedEvent()
        {
            LevelSelected?.Invoke(this);
        }
    }
}

