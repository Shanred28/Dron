using System;
using System.Collections;
using UnityEngine;

namespace Hacaton
{
    public class Speaker : MonoBehaviour
    {
        [Serializable]
        public class Speech
        {
            public string Text;
            public float Duration;
        }
        
        [SerializeField] private Sprite m_Avatar;
        public Sprite Avatar => m_Avatar;
        [SerializeField] private string m_Nickname;
        public string Nickname => m_Nickname;
        [SerializeField] private Speech[] m_Messages;
        private int m_CurrentMessage = 0;

        public static Action MessageExpired;
        public void Say()
        {
            StartCoroutine(SayTimely(m_Messages[m_CurrentMessage].Duration));
        }

        private IEnumerator SayTimely(float duration)
        {
            MessageManager.DisplayMessage(this, m_Messages[m_CurrentMessage]);
            m_CurrentMessage++;
            yield return new WaitForSeconds(duration);
            MessageExpired?.Invoke();
        }
 
    }
}

