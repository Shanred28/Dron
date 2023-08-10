using System;
using UnityEngine;

namespace Hacaton
{
    [CreateAssetMenu(menuName ="Upgrades/CommonUpgrade")]
    public class CommonUpgrade : Upgrade
    {
        [Serializable]
        private class LevelCost
        {
            [HideInInspector] public int Level;
            public int Cost;
            [HideInInspector] public int LevelCounter = 0;
            public LevelCost(int cost)
            {
                Cost = cost;
                Level = LevelCounter++;
            }

            
        }
        [SerializeField] private LevelCost[] m_Cost;
        public int NextCost
        {
            get
            {
                foreach (var level in m_Cost)
                {
                    if (level.Level == CurrentLevel)
                        return level.Cost;
                }
                return 0;
            }
        }

    }
}

