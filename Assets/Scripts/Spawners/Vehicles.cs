using UnityEngine;

namespace Hacaton
{
    public class Vehicles : MonoBehaviour
    {
        [SerializeField] private float _speedMove;
        [SerializeField] private float _smoothMoveFactor;
        [SerializeField] private float _moveSpeedTurning;
        private Quaternion _targetQuateruion;
        public int numLine;

        private Rigidbody _rigidbody;
        private Transform[] _targetRotation;

        private Chunk _chankLast;

        private void Start () 
        {
            
            _rigidbody = GetComponent<Rigidbody>();
            if(transform.parent != null)
                transform.parent.SetParent(null);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_chankLast != other.transform.root.GetComponent<Chunk>() && other.transform.root.TryGetComponent<Chunk>(out var chunk) )
            {
                
                chunk?.AddList(this);

                if(_chankLast!= null)
                    _chankLast.RemoveList(this);

                _chankLast = chunk;
                switch (chunk.typeRoad)
                {
                    case TypeRoad.Straight:
                        _targetQuateruion = Quaternion.LookRotation(chunk.targetMove[numLine].transform.position - transform.position);
                        _isMoveStraight = true;
                        break;

                    case TypeRoad.Crossroad:
                         MovingCross(chunk);
                         break;
                    case TypeRoad.CrossRoadT:
                        MovingCrossT(chunk);
                        break;

                    case TypeRoad.Turning:
                        TurningLeftRoad(chunk);
                        break;
                }
            }
        }

        private bool _isStopMove;
        private bool _isMoveStraight = true;
        private float _timeTurning;
        private float _evadeRayLength = 2;
        private void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit, _evadeRayLength) && hit.transform.root.TryGetComponent<Vehicles>(out var vehicles))
                _isStopMove = true;
            else
                _isStopMove = false;

            if (_isMoveStraight)
            {
                
                
                if (_isStopMove)
                {
                    _rigidbody.velocity = transform.forward * 0;                    
                }
                
                Vector3 _currentVelocity = _rigidbody.velocity;
                Vector3 forwardVelocity = transform.forward * _speedMove;
                _rigidbody.velocity = Vector3.Lerp(_currentVelocity, forwardVelocity, Time.fixedDeltaTime * _smoothMoveFactor);

                // Turning  angle.
                _rigidbody.rotation = Quaternion.Lerp(transform.rotation, _targetQuateruion, Time.fixedDeltaTime * _moveSpeedTurning);
            }
            else
            {
                // Moving  point Bezier.
                if (_isStopMove)
                {
                   /* print(hit1.transform);*/
                    _timeTurning = _timeTurning;
                }
                else
                    _timeTurning += Time.fixedDeltaTime / _speedMove;

                _rigidbody.position = Bezier.GetPoint(_targetRotation[0].position, _targetRotation[1].position , _targetRotation[2].position , _targetRotation[3].position , _timeTurning);

                // Turning  Bezier.                           
               _rigidbody.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(_targetRotation[0].position - transform.position, _targetRotation[1].position - transform.position, _targetRotation[2].position - transform.position, _targetRotation[3].position - transform.position, _timeTurning)); ; 
            }                   
        }

        private void MovingCross(Chunk chunk)
        {
            // Dist left
            var dist1 = Vector3.Distance(transform.position, chunk.endChunks[0].transform.position);
            //Dist Right
            var dist2 = Vector3.Distance(transform.position, chunk.endChunks[1].transform.position);
            //Dist forward
            var dist3 = Vector3.Distance(transform.position, chunk.endChunks[2].transform.position);
  
            if (dist1 < dist2 && dist1 < dist3)
            {
                TurningLeftRoad(chunk);
            }

            else if (dist2 < dist1 && dist2 < dist3 )
            {
                TurningRightRoad(chunk);
            }
            else
            {
                if (numLine == 0)
                {
                    _targetQuateruion = Quaternion.LookRotation(chunk.targetMoveLeftToRightLine1[3].transform.position - transform.position);                          
                }
                else
                {
                    _targetQuateruion = Quaternion.LookRotation(chunk.targetMoveLeftToRightLine2[3].transform.position - transform.position);                           
                }
                _isMoveStraight = true;                       
            }
        }

        private void MovingCrossT(Chunk chunk)
        {
            // Dist left
            var dist1 = Vector3.Distance(transform.position, chunk.endChunks[0].transform.position);
            //Dist Right
            var dist2 = Vector3.Distance(transform.position, chunk.endChunks[1].transform.position);

            if (dist1 < dist2)
            {
                TurningLeftRoad(chunk);
            }

            else if (dist2 < dist1)
            {
                TurningRightRoad(chunk);
            }
        }

        private void TurningLeftRoad(Chunk chunk)
        {
            if (numLine == 0)
            {
                _targetRotation = chunk.targetMoveLeftToRightLine1;
            }
            else
            {
                _targetRotation = chunk.targetMoveLeftToRightLine2;
            }
            _timeTurning = 0;
            _isMoveStraight = false;
        }
        private void TurningRightRoad(Chunk chunk)
        {
            if (numLine == 0)
            {
                _targetRotation = chunk.targetMoveRightToLeftLine1;
            }
            else
            {
                _targetRotation = chunk.targetMoveRightToLeftLine2;             
            }
            _timeTurning = 0;
            _isMoveStraight = false;
        }

        public void DestroyCar()
        { 
         Destroy(gameObject);
        }
    }
}

