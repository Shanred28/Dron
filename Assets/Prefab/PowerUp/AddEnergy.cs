using UnityEngine;

namespace Hacaton
{
    public class AddEnergy : MonoBehaviour
    {
        [SerializeField] private int _addEnergy;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                dron.AddEnergy(_addEnergy);
                Destroy(gameObject);
            }
        }
    }
}

