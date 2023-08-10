using UnityEngine;

namespace Hacaton
{
    [CreateAssetMenu]
    public class PlacerChunksAnLevel : ScriptableObject
    {
        [SerializeField] public Chunk[] chunkPrefabs;
        [SerializeField] public Chunk firstChunk;
        [SerializeField] public Chunk endingChunk;

        [SerializeField] public Turning[] turningCross;
    }
}

