using UnityEngine;

namespace Hacaton
{
    public class SpawnerVehicles : MonoBehaviour
    {
        [SerializeField] private Vehicles[] _prefabVechicles;
        [SerializeField] private Transform[] _spawnPlace;

        [SerializeField] private float _timeIntervalSpawn;

        private Timer _timeIntervalSpawnTimer;



        private void Start () 
        {
            InitTimers();
        }

        private void Update()
        {
            UpdateTimers();
            if(_timeIntervalSpawnTimer.IsFinished)
                 SpawnVehicle();
        }

        private void SpawnVehicle()
        {

            int rndPrefVehicle = Random.Range(0, _prefabVechicles.Length);
            int rndTargetPoint = Random.Range(0, _spawnPlace.Length);

            Vehicles car = Instantiate(_prefabVechicles[rndPrefVehicle], _spawnPlace[rndTargetPoint].position, _spawnPlace[rndTargetPoint].rotation);
            car.numLine = rndTargetPoint;

            _timeIntervalSpawnTimer.Restart();
                 
        }

        private void InitTimers()
        {
            _timeIntervalSpawnTimer = new Timer(_timeIntervalSpawn);
        }

        private void UpdateTimers()
        {
            _timeIntervalSpawnTimer.RemoveTime(Time.deltaTime);
        }
    
    }
}

