using UnityEngine;

namespace Hacaton
{
    public class BoxMail : MonoBehaviour
    {
        [SerializeField] private GradeBox _boxGrade;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                Player.Instance.AddBoxMail();
                Inventory.Instance.AddBox(_boxGrade);
                Destroy(gameObject);
            }
        }
    }
}

