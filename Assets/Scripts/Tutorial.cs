using UnityEngine;

namespace Hacaton
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private GameObject _convasTutorial;
        
        private void Start () 
        { 
            Time.timeScale = 0;
        }

        public void ClickButtonNext()
        {
            Time.timeScale = 1.0f;
            _convasTutorial.SetActive(false);
        }
    }
}

