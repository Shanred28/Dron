using UnityEngine;
using UnityEngine.Events;

namespace Hacaton
{

    public class LevelController : SingletonBase<LevelController>
    {
        [SerializeField] private int m_ReferenceTime;
        public int RefereenceTime => m_ReferenceTime;

        private float m_LevelTime;
        public float LevelTime => m_LevelTime;

        [SerializeField] private UnityEvent m_EventLevelCompleted;

        private bool m_IsLevelCompleted;


/*        private void CheckLevelConditions()
        {

                LevelSequenceController.Instance?.FinishCurrentLevel(true);
        }*/

        public void FinishWin()
        {
            LevelSequenceController.Instance?.FinishCurrentLevel(true);
        }
        public void FinishLose()
        {
            LevelSequenceController.Instance?.FinishCurrentLevel(false);
        }
    }
}

