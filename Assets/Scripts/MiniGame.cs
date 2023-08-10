using UnityEngine;

namespace Hacaton
{
    public interface IsWinPosition
    { 
       bool IsWinPosition { get; }
    }

    public class MiniGame : MonoBehaviour
    {
        [SerializeField] private TriggerHack triggerHack;

        private IsWinPosition[] _conditions;
        private bool _isWin = false;

        private void Start()
        {
            _conditions = GetComponentsInChildren<IsWinPosition>();
        }

        private void Update()
        {
            if (!_isWin)
                CheckWinPosition();

                
        }

        private void CheckWinPosition()
        {
            if (_conditions == null || _conditions.Length == 0) return;
            int numCompleted = 0;
            foreach (var v in _conditions)
            {
                if (v.IsWinPosition)
                    ++numCompleted;
            }

            if (numCompleted == _conditions.Length)
            {
                _isWin = true;
                triggerHack.GameResult();
            }

        }


    }
}

