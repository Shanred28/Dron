using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    [CreateAssetMenu(menuName ="Levels/AllLevels")]
    public class Levels : ScriptableObject
    {
        [SerializeField] private Level[] m_Levels;
        public FarmLevel[] FarmLevels
        {
            get
            {
                var farmList = FarmAsList;
                return farmList.ToArray();
            }
        }
        public MainLevel[] MainLevels
        {
            get
            {
                var mainList = MainAsList;
                return mainList.ToArray();
            }
        }
        public List<FarmLevel> FarmAsList
        {
            get
            {
                var list = new List<FarmLevel>();
                foreach (var level in m_Levels)
                {
                    if (level.Type == LevelType.Farm)
                        list.Add(level as FarmLevel);
                }
                return list;
            }
        }
        
        public List<MainLevel> MainAsList
        {
            get
            {
                var list = new List<MainLevel>();
                foreach (var level in m_Levels)
                {
                    if (level.Type == LevelType.Main)
                        list.Add(level as MainLevel);
                }
                return list;
            }    
            
        }
        public FarmLevel[] AllAvailableFarmLevels
        {
            get
            {
                var list = new List<FarmLevel>();
                foreach (var level in FarmLevels)
                    if (level.IsAvailable())
                        list.Add(level);
                return list.ToArray();
            }
        }

        public MainLevel[] AllAvailableMainLevels
        {
            get
            {
                var list = new List<MainLevel>();
                foreach (var level in MainLevels)
                    if (level.IsAvailable())
                        list.Add(level);
                return list.ToArray();
            }
        }

    }
}

