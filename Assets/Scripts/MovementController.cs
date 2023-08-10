using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Dron _dron;

        [SerializeField] private Button _upButton;
        [SerializeField] private PointerClickHold _leftButton;
        [SerializeField] private PointerClickHold _rightButton;
        [SerializeField] private Button _downButton;
        [SerializeField] private PointerClickHold _boostSpeed;

        private void Update()
        {
            Control();
        }

        private void Control()
        {

            if (_leftButton.IsHold == true)
            { 
                _dron.SideMove = -1;
            }

            else if (_rightButton.IsHold == true)
            {
                _dron.SideMove = 1;
            }

            else
            {
                _dron.SideMove = 0;
            }

            if (_boostSpeed.IsHold)
                _dron.BoostSpeed();
        }

        public void OnClickUp()
        {
            _dron.LiftUp = true;
            _dron.LiftDown = false;
        }
        public void OnClickDown()
        { 
            _dron.LiftDown = true;
            _dron.LiftUp = false;
        }
    }
}

