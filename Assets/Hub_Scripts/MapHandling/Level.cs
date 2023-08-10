using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEditor.FilePathAttribute;

namespace Hacaton
{
    public enum LevelType
    {
        Main,
        Farm
    }
    public abstract class Level : ScriptableObject
    {
        [SerializeField] private LevelType m_Type;
        [SerializeField] private Episode m_Episode;
        public LevelType Type => m_Type;
        public Episode Episode => m_Episode;

        [SerializeField] protected bool m_IsAvailable = false;
        
        [SerializeField] private bool m_IsAddedToMap = false;
        public bool IsAddedToMap {get { return m_IsAddedToMap; } set { m_IsAddedToMap = value; } }
        // DEBUG
        [SerializeField] private bool m_IsCompleted = false;
        public bool IsCompleted => m_IsCompleted;
        public virtual void LoadLevel()
        {
            LevelSequenceController.Instance.StartMission(Episode);
        }

        public string Location => $"�����: {m_Episode.LevelLocation}";
        public string Reward => $"�������: {m_Episode.LevelReward}";
        public string Cargo
        {
            get
            {
                string cargo = "�������";
                switch (m_Episode.Cargo.TypeCargo)
                {
                    case CargoType.VeryFragile:
                        cargo = "����� �������";
                        break;
                    case CargoType.Fragily:
                        cargo = "�������";
                        break;
                }

                return $"����: {cargo}";
            }
        }
        public virtual bool IsAvailable() => m_IsAvailable;
    }
}

