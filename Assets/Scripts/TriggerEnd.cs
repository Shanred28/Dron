using UnityEngine;

namespace Hacaton
{
    public class TriggerEnd : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                LevelController.Instance.FinishWin();
            }
        }
    }
}


