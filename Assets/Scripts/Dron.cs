using System;
using UnityEngine;
using UnityEngine.Events;

namespace Hacaton
{
    [RequireComponent(typeof(Rigidbody))]
    public class Dron : SingletonBase<Dron>
    {
        [Header("StatDron")]
        // Нужна будет для ускорение и взлома
        [SerializeField] private float _maxEnergy;
        public float MaxEnergy => _maxEnergy;
        private float _currentEnergy;
        public float CurrentEnergy => _currentEnergy;
        [SerializeField] private int _removeEnergyHack;
        [SerializeField] private float _Up;
        [SerializeField] private float _flySpeed;
        [SerializeField] private float _flySpeedTurning;
        
        [SerializeField] private float _prowl;

        [Header("PhisicFly")]
        //[SerializeField] private float _gravity;
        [SerializeField] private float _smoothFlyFactor;

        [Header("BoostSpeed")]
        [SerializeField] private float _addBoostSpeed;
        [SerializeField] private int _countEnergyBoostSpeed;
        [SerializeField] private float _timeBoostSpeed;

        private bool _IsBoostSpeed = false;

        private Rigidbody _rigidbody;
        private Animator _animator;


        [HideInInspector] public float SideMove;
        [HideInInspector] public bool LiftUp;
        [SerializeField] private float _upSide;
        [HideInInspector] public bool LiftDown;
        [SerializeField] private float _downSide;

        [HideInInspector] public UnityEvent CrashedEvent;

        [HideInInspector] public float ForceCrashed;

        public Cargo cargoDron;
        private Timer _timerBoostSpeed;

        // Изменить этот ужас, на State Mashin
        private float _defoultSlopeCentr = 0.50f;
        private float timeSlopeLeft = 0.50f;
        private float timeSlopeRight = 0.50f;


        private void Start () 
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            cargoDron = GetComponentInChildren<Cargo>();
            _animator.SetFloat("Blend", _defoultSlopeCentr);
            _currentEnergy = _maxEnergy;
            InitTimers();
        }

        private void Update()
        {
            UpdateTimers();
            if (_timerBoostSpeed.IsFinished)
            {
                _IsBoostSpeed = false;
                NormalSpeed();
            }               
        }

        private void FixedUpdate()
        {
            //Side move
            _rigidbody.AddForce(transform.right * SideMove * _prowl, ForceMode.Impulse);

            // Изменить этот ужас, на State Mashin
            if (SideMove > 0)
            {
                timeSlopeRight +=  0.01f;
                AnimationSlope(timeSlopeRight);
            }
            if (SideMove < 0)
            {
                timeSlopeLeft -= 0.01f;
                AnimationSlope(timeSlopeLeft);
            }
            if (SideMove == 0)
            {
                AnimationSlope(_defoultSlopeCentr);
                timeSlopeRight = _defoultSlopeCentr;
                timeSlopeLeft = _defoultSlopeCentr;
            }

            // Up-down move
            if (LiftUp)
            {
                // _rigidbody.AddForce(0, _Up, 0, ForceMode.Impulse);
                if (transform.position.y < _upSide && LiftUp == true)
                {
                    transform.position += Vector3.up * Time.fixedDeltaTime;                   
                }
                else
                {
                    LiftUp = false;
                }
            }
            if (LiftDown) 
            {
                //_rigidbody.AddForce(0, -_Up, 0, ForceMode.Impulse);
                if (transform.position.y > _downSide && LiftDown == true)
                {
                    transform.position += (Vector3.up * -1) * Time.fixedDeltaTime;
                }
                else
                {
                    LiftDown = false;
                }
            }

            // Forward Movement
            Vector3 _currentVelocity = _rigidbody.velocity;
            Vector3  forwardVelocity = transform.forward * _flySpeed;
            _rigidbody.velocity = Vector3.Lerp(_currentVelocity, forwardVelocity, Time.fixedDeltaTime * _smoothFlyFactor);

        
            // Turning Dron angle
            _rigidbody.rotation = Quaternion.Lerp(transform.rotation, _targetQuateruion, Time.fixedDeltaTime * _flySpeedTurning);

        }

        private Quaternion _targetQuateruion;
       
        public void TurningDron(Quaternion quaternion )
        {
            _targetQuateruion = quaternion;
        }

        public void Crashed(float forceCrashed)
        {
            ForceCrashed = forceCrashed;
            CrashedEvent.Invoke();
            if (transform.position.y != _downSide || transform.position.y != _upSide)
            {
                var distUp = Vector3.Distance(transform.position, new Vector3(transform.position.x, _upSide, transform.position.z)); 
                var distDown = Vector3.Distance(transform.position, new Vector3(transform.position.x, _downSide, transform.position.z));
                if (distUp > distDown)
                {
                    LiftDown = true;
                }
                else
                    LiftUp = true;
            }
            // Надо сюда анимаху,после столкновения с препятствием
        }

        private void AnimationSlope(float timeSlope)
        {
            _animator.SetFloat("Blend", timeSlope);
            
        }

        public void BoostSpeed()
        {
            if (_currentEnergy >= _countEnergyBoostSpeed && _IsBoostSpeed == false)
            {
                _flySpeed = _flySpeed * _addBoostSpeed;
                _timerBoostSpeed.Start(_timeBoostSpeed);
                _IsBoostSpeed = true;
                RemoveEnergy(_countEnergyBoostSpeed);
            }           
        }
        private void NormalSpeed()
        {
            _flySpeed = _flySpeed / _addBoostSpeed;
            _timerBoostSpeed.Stop();
        }

        private void InitTimers()
        {
            _timerBoostSpeed = new Timer(_timeBoostSpeed);
            _timerBoostSpeed.Stop();
        }

        private void UpdateTimers()
        {
            _timerBoostSpeed.RemoveTime(Time.deltaTime);
        }

        private void RemoveEnergy(int energy)
        {
            _currentEnergy = _currentEnergy - energy;
        }

        public void AddEnergy(int energy)
        {
            _currentEnergy += energy;
            if(_currentEnergy > _maxEnergy)
                _currentEnergy = _maxEnergy;
        }

        public void Hack()
        {
            RemoveEnergy(_removeEnergyHack);
        }

        //Todo взрыв партикле
        internal void CrashObstacle()
        {
            LevelController.Instance.FinishLose();
        }
    }
}

