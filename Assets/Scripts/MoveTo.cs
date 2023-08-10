using UnityEngine;

namespace Hacaton
{
    public class MoveTo : MonoBehaviour
    {
        [SerializeField] private Transform _transformMove;
        [SerializeField] private Transform _transformTarget;
        [SerializeField] private float _speedMove;

        public bool IsStart = false;

        private void Update()
        {
            if(IsStart)
               _transformMove.localPosition= Vector3.MoveTowards(_transformMove.localPosition, _transformTarget.localPosition, _speedMove * Time.deltaTime);
        }
    }
}

