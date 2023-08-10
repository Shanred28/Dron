using TMPro;
using UnityEngine;

namespace Hacaton
{
    public class LevelInfoUpdaterUI : SingletonBase<LevelInfoUpdaterUI>
    {
        [SerializeField] private GameObject m_InfoPanel;
        [SerializeField] private TMP_Text m_Location;
        [SerializeField] private TMP_Text m_Reward;
        [SerializeField] private TMP_Text m_Cargo;
        private MapLevel m_SelectedLevel;
        public MapLevel SelectedLevel { get { return m_SelectedLevel; }
            private set 
            { 
                SwitchCam(value);
            } 
        }

        private void Start()
        {
            MapLevel.LevelSelected += OnLevelChange;
        }

        public static void Init(MapLevel level)
        {
            Instance.SelectedLevel = level;
        }
        public static void Deactivate()
        {
            Instance.m_InfoPanel.SetActive(false);
        }

        public static void ShowPanel()
        {
            Instance.m_InfoPanel.SetActive(true);
        }

        private void OnLevelChange(MapLevel level)
        {
            m_Location.text = $"Место: {level.LevelEpisode.LevelLocation}";
            m_Reward.text = $"Награда: {level.LevelEpisode.LevelReward}";
            string cargo = "Обычный";
            switch (level.LevelEpisode.Cargo.TypeCargo)
            {
                case CargoType.VeryFragile:
                    cargo = "Очень хрупкий";
                    break;
                case CargoType.Fragily:
                    cargo = "Хрупкий";
                    break;
            }
            
            m_Cargo.text = $"Груз: {cargo}";
            SwitchCam(level);
            ShowPanel();
        }

        private void SwitchCam(MapLevel newLevel)
        {
            if (m_SelectedLevel)
                m_SelectedLevel.SwitchCam(false);
            newLevel.SwitchCam(true);
            m_SelectedLevel = newLevel;
        }

        private void OnDestroy()
        {
            MapLevel.LevelSelected -= OnLevelChange;

        }
    }
}

