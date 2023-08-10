using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacerStory : MonoBehaviour
    {

        [SerializeField] private PlacerChunksAnLevel _placerChunks;

        private Chunk _lastChunk;
        private int _indexChunk = 0;

        private void Start () 
        {
            Chunk newFirstChunk = Instantiate(_placerChunks.firstChunk);
            _lastChunk = newFirstChunk;

            foreach (var chunk in _placerChunks.chunkPrefabs) 
            {
                if (_indexChunk == _placerChunks.chunkPrefabs.Length)
                {
                    var end = Instantiate(_placerChunks.endingChunk, _lastChunk.endChunks[0].position, _lastChunk.endChunks[0].rotation);
                    break;
                }

                if (_lastChunk.typeRoad == TypeRoad.Crossroad)
                {
                    var turning = _placerChunks.turningCross[0];
                    _lastChunk.GetComponent<TurningDron>().turning = turning;
                    _lastChunk.turningCross = turning;
                    switch (turning)
                    {
                        case Turning.Left:
                           
                            SetPlaceStopCross(_lastChunk.endChunks[1], _lastChunk.endChunks[2]);
                            SetPlace(_lastChunk.endChunks[0]);
                            break;

                        case Turning.Right:
                           
                            SetPlaceStopCross(_lastChunk.endChunks[0], _lastChunk.endChunks[2]);
                            SetPlace(_lastChunk.endChunks[1]);

                            break;

                        case Turning.Forward:
                            
                            SetPlaceStopCross(_lastChunk.endChunks[0], _lastChunk.endChunks[1]);
                            SetPlace(_lastChunk.endChunks[2]);

                            break;

                    }
                }
                else if (_lastChunk.typeRoad == TypeRoad.CrossRoadT)
                {
                    var turning1 = _placerChunks.turningCross[1];
                    _lastChunk.GetComponent<TurningDron>().turning = turning1;

                    switch (turning1)
                    {
                        case Turning.Left:
                            
                            SetPlaceStopAngleT(_lastChunk.endChunks[1]);
                            SetPlace(_lastChunk.endChunks[0]);

                            break;

                        case Turning.Right:
                            
                            SetPlaceStopAngleT(_lastChunk.endChunks[0]);
                            SetPlace(_lastChunk.endChunks[1]);

                            break;
                    }
                }
                else
                {
                        var endPoit = _lastChunk.endChunks[0];
                        SetPlace(endPoit);
                }                
            }         
        }


        #region  Instantiate and placing a chunk
        private void SetPlaceStopCross(Transform transform, Transform transform1)
        {

           Chunk newChunk = Instantiate(_placerChunks.chunkPrefabs[_indexChunk++], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);

            Chunk newChunk2 = Instantiate(_placerChunks.chunkPrefabs[_indexChunk++], transform1.position, transform1.rotation);
            newChunk2.transform.position += Offset(newChunk2);
        }

        private void SetPlaceStopAngleT(Transform transform)
        {
            Chunk newChunk = Instantiate(_placerChunks.chunkPrefabs[_indexChunk++], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);

        }
        private void SetPlace(Transform transform)
        {
            Chunk newChunk = Instantiate(_placerChunks.chunkPrefabs[_indexChunk++], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);
            _lastChunk = newChunk;
        }

        protected Vector3 Offset(Chunk chunk)
        {
            var offset = chunk.transform.position - chunk.beginChunk.transform.position;
            return offset;
        }
        #endregion
    }
}

