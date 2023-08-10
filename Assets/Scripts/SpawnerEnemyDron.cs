using UnityEngine;

namespace Hacaton
{
    public class SpawnerEnemyDron : MonoBehaviour
    {
        [SerializeField] private EnemyDron _prefabEnemyDron;

        [SerializeField] private float _timeIntervalSpawn;
        [SerializeField] private int _maxRespawnVechicles;
        [SerializeField] private Transform _targetMove;

        [SerializeField] private Vector3 _centr;
        [SerializeField] private Vector3 _size;

        private Timer _timerIntervalSpawnTimer;

        private void Start () 
        {
            SpawnEnemyDron();
            InitTimers();
        }

        private void Update () 
        {
            UpdateTimers();
            if (_timerIntervalSpawnTimer.IsFinished == true)
            {
                _timerIntervalSpawnTimer.Restart();
                SpawnEnemyDron();
            }    
               
        }

        private void SpawnEnemyDron()
        {
            Vector3 pos = transform.localPosition + new Vector3(Random.Range(-_size.x / 2, _size.x / 2), Random.Range(-_size.y / 2, _size.y / 2), Random.Range(-_size.z / 2, _size.z / 2));
            Vector3 posLook = _targetMove.position - transform.position;

           EnemyDron dron = Instantiate(_prefabEnemyDron,pos,Quaternion.LookRotation(posLook));

            dron.SetMoveTarget(_targetMove);
            
        }

        private void InitTimers()
        {
            _timerIntervalSpawnTimer = new Timer(_timeIntervalSpawn);
        }

        private void UpdateTimers()
        {
            _timerIntervalSpawnTimer.RemoveTime(Time.deltaTime);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
             Gizmos.color = Color.red;
             Gizmos.DrawCube(transform.position, _size);
        }
#endif
    }
}