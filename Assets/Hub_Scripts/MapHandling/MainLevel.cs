using UnityEngine;

namespace Hacaton
{
    [CreateAssetMenu(menuName = "Levels/MainLevel")]
    public class MainLevel : Level 
    {
        public void SetAvailable()
        {
            m_IsAvailable = true;
        }
    }
}

