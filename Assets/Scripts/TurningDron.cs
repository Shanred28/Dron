using UnityEngine;

namespace Hacaton
{
    public enum Turning
    {
        Left,
        Right,
        Forward
    }

    [RequireComponent(typeof(Collider))]
    public class TurningDron : MonoBehaviour
    {    
        [SerializeField] public Turning turning;

        private bool IsTurn;
        private Chunk chunk;

        private void Start()
        {
            chunk = GetComponent<Chunk>();
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                if (turning == Turning.Left && IsTurn == false)
                {                  
                    dron.TurningDron(chunk.endChunks[0].rotation);
                    IsTurn = true;
                }           
                
                if (turning == Turning.Right)
                {
                    dron.TurningDron(chunk.endChunks[1].rotation);
                    IsTurn = true;
                }                       
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
                IsTurn = false;
        }
    }
}

