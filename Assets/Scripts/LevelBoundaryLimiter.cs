using UnityEngine;

namespace Hacaton
{
    public class LevelBoundaryLimiter : MonoBehaviour
    {
        private void Update()
        {
            if (LevelBoundary.Instance == null) return;

            var lb = LevelBoundary.Instance;
            float h = lb.Height;

            if (transform.position.y > h)
            {
                transform.position = new Vector3(transform.position.x, h, transform.position.z);
            }
        }
    }
}
