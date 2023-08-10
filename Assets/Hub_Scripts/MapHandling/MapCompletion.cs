using System;
using UnityEngine;

namespace Hacaton
{
    public class MapCompletion : SingletonBase<MapCompletion>
    {
        /*private static int IDCounter = 0;

        [Serializable]
        private class EpisodeResults
        {
            public Episode EpisodeInstance;
            public int Score;
            private int m_ResultID = IDCounter++;

            public EpisodeSave ExportToSave()
            {
                return new EpisodeSave(m_ResultID, Score);
            }
            public static void ImportFromSave(EpisodeSave save, EpisodeResults[] episodeResults)
            {
                foreach (var result in episodeResults)
                {
                    if (result.m_ResultID == save.EpisodeID)
                    {
                        result.Score = save.Score;
                    }
                }
            }
            
        }
        [Serializable]
        private class EpisodeSave
        {
            public int EpisodeID;
            public int Score;

            public EpisodeSave (int id, int score)
            {
                EpisodeID = id;
                Score = score;
            }
        }*/
        [Serializable]
        private class EpisodeResults : SaverMisc<Episode>.Data { }

        public const string DataFile = "EpisodeResults.dat";
        [SerializeField] private EpisodeResults[] m_EpisodeData;

        public int GetEpisodeScore(Episode episode)
        {
            
            foreach(var data in m_EpisodeData)
            {
                if (data.Instance == episode)
                    return data.Value;
            }
            return 0;
        }

        public static void SaveEpisodeResults(int levelScore)
        {
            if (Instance)
                Instance.SaveResult(LevelSequenceController.Instance.CurrentEpisode, levelScore);
        }

        
        
        private int m_TotalScore;

        // [SerializeField] private EpisodeResults[] m_BranchEpisodeData;
        public int TotalScore 
        {
            get
            {
                int totalScore = 0;
                foreach (var episodeData in m_EpisodeData)
                    totalScore += episodeData.Value;
                return totalScore;
            }
        }
        private new void Awake()
        {
            base.Awake();
            var loadData = new SaverMisc<Episode>.Save[m_EpisodeData.Length];
            Saver<SaverMisc<Episode>.Save[]>.TryLoad(DataFile, ref loadData);
            //if (loadData == null) return;
            if (loadData.Length > 0)
            {
                for (int i = 0; i < loadData.Length; i++)
                {
                    if (loadData[i] != null)
                        EpisodeResults.ImportFromSave(loadData[i], m_EpisodeData);
                }
            }
        }

        private void SaveResult(Episode currentEpisode, int levelScore)
        {
            foreach (var data in m_EpisodeData)
            {
                if (data.Instance == currentEpisode)
                {
                    data.Value = data.Value > levelScore ? data.Value : levelScore;
                    var saveData = new SaverMisc<Episode>.Save[m_EpisodeData.Length];
                    for (int i = 0; i < m_EpisodeData.Length; i++)
                    {
                        saveData[i] = m_EpisodeData[i].ExportToSave();
                    }
                    Saver<SaverMisc<Episode>.Save[]>.Save(DataFile, saveData);
                }
            }
        }
    }
}

