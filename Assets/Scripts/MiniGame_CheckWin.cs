using UnityEngine;

namespace Hacaton
{
    public class MiniGame_CheckWin : MonoBehaviour, IsWinPosition
    {
        // Position rotation image.
        [Range(1,4)]
        [SerializeField] private int _pos;
        private bool _isPositionTrue = false;
        private bool _reached = false;


        public void CheckPosition()
        {
            transform.Rotate(new Vector3(0, 0, 90));
            ++_pos;
            Debug.Log(_pos);
            if (_pos > 4)
                _pos = 1;
            if (_pos == 1 || _pos == 3 )
                _isPositionTrue = true;
            
            else
                _isPositionTrue = false;
        }
        bool IsWinPosition.IsWinPosition
        {
            get
            {
                if (_isPositionTrue)
                {
                    _reached = true;
                    return _reached;
                }
                else
                {
                    _reached = false;
                    return _reached;
                }


            }
        }
    }
}

