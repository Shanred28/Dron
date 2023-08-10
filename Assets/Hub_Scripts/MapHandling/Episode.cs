using UnityEngine;

namespace Hacaton
{
    [CreateAssetMenu]
    public class Episode : ScriptableObject
    {
        [SerializeField] private string m_EpisodeName;
        public string EpisodeName => m_EpisodeName;

        [SerializeField] private string[] m_Levels;
        public string[] Levels => m_Levels;

        [SerializeField] private Sprite m_PreviewImage;
        public Sprite PreviewImage => m_PreviewImage;

        [SerializeField] private string m_LevelLocation;
        public string LevelLocation => m_LevelLocation;

        [SerializeField] private int m_Reward;
        public string LevelReward => m_Reward.ToString();

        [SerializeField] private CagroProperties m_Cargo;
        public CagroProperties Cargo => m_Cargo;

        private bool m_IsCompleted;
        public bool IsCompleted { get => m_IsCompleted; set => m_IsCompleted = value; }

        // DEBUG: Спрятать в инспекторе
        public bool IsAddedToMap;
        // DEBUG: Спрятать в инспекторе
        public bool IsAddedToAdverts;
    }
}

