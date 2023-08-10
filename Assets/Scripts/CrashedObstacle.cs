using UnityEngine;

namespace Hacaton
{
    public class CrashedObstacle : MonoBehaviour
    {
        // Repulsive force, for rigi
        [SerializeField] private float _collisionForce;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                var rb =dron.GetComponent<Rigidbody>();
                var collisionNormal = collision.contacts[0].normal;
                rb.AddForce(collisionNormal * _collisionForce, ForceMode.Impulse);
                dron.Crashed(_collisionForce);              
            }
        }
    }
}

