using UnityEngine;

namespace Hacaton
{
    public class RotateTransform : MonoBehaviour
    {
        [SerializeField] private Vector3 speed;


        private void Update()
        {
            transform.Rotate(speed * Time.deltaTime);
        }
    }
}