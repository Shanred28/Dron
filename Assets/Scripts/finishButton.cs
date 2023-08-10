using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hacaton
{
    public class finishButton : MonoBehaviour
    {
        public int sceneNumber;
        public void ChangeScenes()
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}

