using System;
using UnityEngine;

namespace Hacaton
{
    public enum Type
    {
        Common,
        Unique
    }
    public enum UpgradablePart
    {
        Fans,
        Motors,
        Battery,
        CargoPlatform,
        ShockAbsorbers
    }

    public abstract class Upgrade : ScriptableObject
    {
        [Serializable]
        private class UpgradeLevel
        {
            public int Level;
            public int Value;
        }
        [SerializeField] private Type m_Type;
        public Type Type => m_Type;

        [SerializeField] private UpgradeLevel[] m_Levels;
        public int CurrentValue 
        { 
            get
            {
                foreach (var level in m_Levels)
                {
                    if (level.Level == CurrentLevel)
                        return level.Value;
                }
                return 0;
            }
        }
        public int this[int i]
        {
            get
            {
                if (i >= m_Levels.Length)
                {
                    Debug.Log($"Attempt to pick higher upgrade level then maximum at {name}");
                    return -1;
                }
                foreach (var level in m_Levels)
                {
                    if (level.Level == i)
                        return level.Value;
                }
                return 0;
            }
        }
        [SerializeField] private string m_UpgradeName;
        public string UpgradeName => m_UpgradeName;

        [SerializeField] private string m_Description;
        public string Description => m_Description;

        [SerializeField] private UpgradablePart m_Part;
        public UpgradablePart Part => m_Part;

        [SerializeField] private Sprite m_UpgradeIcon;
        public Sprite UpgradeIcon => m_UpgradeIcon;
        // DEBUG
        [SerializeField] private int m_CurrentLevel;
        public int CurrentLevel => m_CurrentLevel;
        public int MaximumLevel => m_Levels.Length;

        [SerializeField] private Level m_RootLevel;
        public Level RootLevel => m_RootLevel;

        // DEBUG
        [SerializeField] bool m_IsAvailable;
        public bool IsAvailable
        {
            get
            {
                m_IsAvailable = m_RootLevel == null? true : m_RootLevel.IsCompleted;
                return m_IsAvailable;
            }
        }
        public string GetEffectType()
        {
            switch (Part)
            {
                case UpgradablePart.Fans:
                    return "Скорость верт.";
                case UpgradablePart.Battery:
                    return "Энергия";
                case UpgradablePart.Motors:
                    return "Скорость лин.";
                case UpgradablePart.CargoPlatform:
                    return "Грузоподъемность";
                case UpgradablePart.ShockAbsorbers:
                    return "Повреждаемость";
            }
            return "";
        }
    }
}

