using UnityEngine;

namespace Hacaton
{
    public class EnemyDron : MonoBehaviour
    {
        [SerializeField] private float _speedMove;
        [SerializeField] private GameObject _particleEffect;

        private Vector3 _MoveTarget;

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, _MoveTarget, _speedMove * Time.deltaTime);
            if (transform.position == _MoveTarget)
            {
                Destroy(gameObject);
            }

        }

        public void SetMoveTarget(Transform target)
        {
            _MoveTarget = target.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                Instantiate(_particleEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}

