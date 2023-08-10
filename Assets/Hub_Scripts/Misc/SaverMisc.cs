using System;

namespace Hacaton
{
    public abstract class SaverMisc<T>
    {
        private static int IDCounter = 0;
        public Data ApplicableData;

        [Serializable]
        public class Data
        {
            public T Instance;
            public int Value;
            private int m_ID = IDCounter++;

            public Save ExportToSave()
            {
                return new Save(m_ID, Value);
            }
            public static void ImportFromSave(Save save, Data[] episodeResults)
            {
                foreach (var result in episodeResults)
                {
                    if (result.m_ID == save.ID)
                    {
                        result.Value = save.Value;
                    }
                }
            }

        }
        [Serializable]
        public class Save
        {
            public int ID;
            public int Value;

            public Save(int id, int value)
            {
                ID = id;
                Value = value;
            }
        }

    }
}

