using UnityEngine;

namespace Hacaton
{
    public class CrashedObstacleBannerDestrictible : MonoBehaviour
    {
        [SerializeField] private float _collisionForce;

        [SerializeField] private GameObject _banner;
        [SerializeField] private GameObject _bannerPart;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                dron.Crashed(_collisionForce);
                _banner.SetActive(false);
                _bannerPart.SetActive(true);
            }
        }
    }
}


