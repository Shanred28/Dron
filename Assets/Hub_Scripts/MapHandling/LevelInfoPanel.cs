using UnityEngine;


namespace Hacaton
{
    public class LevelInfoPanel : MonoBehaviour
    {
        public void Play()
        {
            LevelInfoUpdaterUI.Instance.SelectedLevel.LoadLevel();
        }
        public void Return()
        {
            LevelInfoUpdaterUI.Deactivate();
        }
    }
}

