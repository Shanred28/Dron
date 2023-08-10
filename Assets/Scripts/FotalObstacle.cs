using System.Threading;
using UnityEngine;

namespace Hacaton
{
    public class FotalObstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out var dron))
            {
                dron.CrashObstacle();
            }
                
        }
    }
}

