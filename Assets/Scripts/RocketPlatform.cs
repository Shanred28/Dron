using UnityEngine;

namespace Hacaton
{
    public class RocketPlatform : MonoBehaviour
    {
        [SerializeField] private float _liftUpDawn;
        [SerializeField] private float _distLift;
        [SerializeField] private bool _isMove = false;
        [SerializeField] private BoxMail _boxMail;
        [SerializeField] private float _timeDestroy;

        private Timer _timerDestroy;

        private Vector3 defoultPosition;
        private bool _isUp = true;

        private void Start () 
        {
            defoultPosition = transform.position;
            _timerDestroy = new Timer(_timeDestroy); 
        }

        private void FixedUpdate()
        {
            if (_isMove)
            {
                Vector3 liftUp;
                float distUpPos = transform.position.y - defoultPosition.y;
                if (_isUp == true)
                {
                    liftUp = transform.up * _liftUpDawn;
                    transform.Translate(liftUp * Time.fixedDeltaTime);
                    if (distUpPos > _distLift)
                    {
                        _isUp = false;
                    }
                }
                if (_isUp == false)
                {
                    liftUp = -transform.up * _liftUpDawn;
                    transform.Translate(liftUp * Time.fixedDeltaTime);
                    if (distUpPos < -_distLift)
                        _isUp = true;
                }
            }

            if (_boxMail == null)
            {
                UpdateTimers();
                if(_timerDestroy.IsFinished)
                    Destroy(gameObject);
            }               
        }

        private void UpdateTimers()
        {
            _timerDestroy.RemoveTime(Time.deltaTime);
        }
    }
}

