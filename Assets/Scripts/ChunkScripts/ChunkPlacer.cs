using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacer : SingletonBase<ChunkPlacer>
    {

        [SerializeField] private Chunk[] _chunkPrefabs;
        [SerializeField] private Chunk[] _chunkCrossPref;
        [SerializeField] private Chunk _firstChunk;
        [SerializeField] private int _chunkRoad;
        [SerializeField] private Chunk[] _roadTurn;



        private int _chunkNumSpawn;

        private List<Chunk>  _spawnedChunks = new List<Chunk>();
        private List<Chunk> _spawnedStopChunks = new List<Chunk>();


        private void Start () 
        {
            Chunk newFirstChunk = Instantiate(_firstChunk);
            _spawnedChunks.Add(newFirstChunk);
            for (int i = 0; i < 8; i++)
            {
                SpawnChunk();
            }

        }

        public void SpawnChunk()
        {
            if (_chunkRoad >= _chunkNumSpawn)
            {
                _chunkNumSpawn++;

                var lastChunk = _spawnedChunks[_spawnedChunks.Count - 1];


                if (_spawnedStopChunks.Count >= 8)
                {
                   StartCoroutine(_spawnedStopChunks[0].WaitTimerDestoryChank());
                   // Destroy( _spawnedStopChunks[0].gameObject );
                    _spawnedStopChunks.RemoveAt(0);
                }

                if (lastChunk.typeRoad == TypeRoad.Crossroad)
                {
                    var endChunk = lastChunk.RandomTurning();
                    var turning = lastChunk.turningCross;
                    SetPlace(endChunk);

                    lastChunk.GetComponent<TurningDron>().turning = turning;
                    switch (turning)
                    {
                        case Turning.Left:

                            SetPlaceStopCross(lastChunk.endChunks[1], lastChunk.endChunks[2]);
                            break;

                        case Turning.Right:

                            SetPlaceStopCross(lastChunk.endChunks[0], lastChunk.endChunks[2]);

                            break;

                        case Turning.Forward:
                            SetPlaceStopCross(lastChunk.endChunks[0], lastChunk.endChunks[1]);
                            break;

                    }
                }
                else if (lastChunk.typeRoad == TypeRoad.CrossRoadT)
                {
                    var endChunk = lastChunk.RandomTurning();
                    var turning1 = lastChunk.turningCross;
                    SetPlace(endChunk);

                    lastChunk.GetComponent<TurningDron>().turning = turning1;


                    switch (turning1)
                    {
                        case Turning.Left:
                            SetPlaceStopAngleT(lastChunk.endChunks[1]);

                            break;

                        case Turning.Right:

                            SetPlaceStopAngleT(lastChunk.endChunks[0]);
                            break;
                    }
                }
                else
                {
                    var endPoit = lastChunk.endChunks[0];
                    SetPlace(endPoit);

                }
            }

            if (_chunkRoad == _chunkNumSpawn)
            {
                _chunkNumSpawn = 0;
                Chunk newChunk = Instantiate(_chunkCrossPref[Random.Range(0, _chunkCrossPref.Length)]);
                var lastChunk = _spawnedChunks[_spawnedChunks.Count - 1];
                var endPoit = lastChunk.endChunks[0];

                newChunk.transform.rotation = endPoit.root.transform.rotation;
                newChunk.transform.position = endPoit.position - newChunk.beginChunk.position;
                _spawnedChunks.Add(newChunk);
            }

            if (_spawnedChunks.Count >= 12)
            {
                StartCoroutine( _spawnedChunks[0].WaitTimerDestoryChank());
               // Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);

            }         
        }
        #region  Instantiate and placing a chunk
        private void SetPlaceStopCross(Transform transform,Transform transform1)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[RandomIndexChunk(_chunkPrefabs.Length)], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);

            Chunk newChunk1 = Instantiate(_chunkPrefabs[RandomIndexChunk(_chunkPrefabs.Length)], transform1.position, transform1.rotation);
            newChunk1.transform.position += Offset(newChunk1);

            Chunk newChunkEnd = Instantiate(_roadTurn[RandomIndexChunk(_roadTurn.Length)], newChunk1.endChunks[0].transform.position, newChunk1.endChunks[0].transform.rotation);
            newChunkEnd.transform.position += Offset(newChunkEnd);

            _spawnedStopChunks.Add(newChunk);
            _spawnedStopChunks.Add(newChunk1);
            _spawnedStopChunks.Add(newChunkEnd);

        }

        private  void SetPlaceStopAngleT(Transform transform)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[RandomIndexChunk( _chunkPrefabs.Length)], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);

            Chunk newChunkEnd = Instantiate(_roadTurn[RandomIndexChunk(_roadTurn.Length)], newChunk.endChunks[0].transform.position, newChunk.endChunks[0].transform.rotation);
            newChunkEnd.transform.position += Offset(newChunk);

            _spawnedStopChunks.Add(newChunk);
            _spawnedStopChunks.Add(newChunkEnd);

        }

        protected void SetPlace(Transform transform)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[RandomIndexChunk(_chunkPrefabs.Length)], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);
            _spawnedChunks.Add(newChunk);
        }

        /// <summary>
        ///  Offset from the end of the previous chunk
        /// </summary>
        /// <param name="chunk"></param>
        /// <returns></returns>
        protected Vector3 Offset(Chunk chunk)
        {
            var offset = chunk.transform.position - chunk.beginChunk.transform.position;
            return offset;
        }

        private int RandomIndexChunk(int endNum)
        {
           var num =  Random.Range(0, endNum);
            return num;
        }
        #endregion
    }

}
