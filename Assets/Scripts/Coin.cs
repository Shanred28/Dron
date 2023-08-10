using UnityEngine;

namespace Hacaton
{
    public class Coin : MonoBehaviour
    {

        [SerializeField] private int _numMoney;
        [SerializeField] private Vector3 _rotateSpeed;
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out var Dron))
            {
                Inventory.Instance.AddMoney(_numMoney);
                Destroy(gameObject);
            }
        }
    }
}