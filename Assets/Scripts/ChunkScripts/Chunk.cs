using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public enum TypeRoad
    {
        Straight,
        Crossroad,
        Turning,
        CrossRoadT
    }
    public class Chunk : MonoBehaviour
    {
        [SerializeField] public Transform beginChunk;
        [SerializeField] public Transform[] endChunks;
        public Transform[] targetMove;
        public Transform[] targetMoveLeftToRightLine1;
        public Transform[] targetMoveLeftToRightLine2;
        public Transform[] targetMoveRightToLeftLine1;
        public Transform[] targetMoveRightToLeftLine2;
        [SerializeField] private float _timeDestroyChank = 6;

        [SerializeField] public TypeRoad typeRoad;
        [HideInInspector] public Turning turningCross;

        private List<Vehicles> _vehiclesAnChanks;

        private void Awake()
        {
            _vehiclesAnChanks = new List<Vehicles>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (ChunkPlacer.Instance != null && other.transform.root.TryGetComponent<Dron>(out var dron))
                ChunkPlacer.Instance.SpawnChunk();
            else if (other.transform.root.TryGetComponent<Dron>(out var dron1))
                StartCoroutine(WaitTimerDestoryChank());

        }

        public Transform RandomTurning()
        {
            var rnd = Random.Range(0, endChunks.Length);
            var endPoint = endChunks[rnd];
            ;
            turningCross = SetTurning(rnd);

            return endPoint;
        }

        private Turning SetTurning(int endPoint)
        {
            switch (endPoint)
            {
                case 0:
                    turningCross = Turning.Left;
                    return turningCross;
                case 1:
                    turningCross = Turning.Right;
                    return turningCross;
                case 2:

                    turningCross = Turning.Forward;
                    return turningCross;
            }
            return turningCross;
        }

        public bool IsDestroy;
        public IEnumerator WaitTimerDestoryChank()
        {
            yield return new WaitForSeconds(_timeDestroyChank);
            foreach (var obj in _vehiclesAnChanks)
            {
                obj.DestroyCar();
            }
            _vehiclesAnChanks.Clear();
            IsDestroy = true;
            Destroy(gameObject);
        }

        public void AddList(Vehicles vehicles)
        {
            _vehiclesAnChanks.Add(vehicles);
        }

        public void RemoveList(Vehicles vehicles)
        {
            _vehiclesAnChanks.Remove(vehicles);
        }
    }
}

