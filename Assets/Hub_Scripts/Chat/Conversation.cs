using System;
using UnityEngine;

namespace Hacaton
{
    public class Conversation : MonoBehaviour
    {
        [SerializeField] private Speaker[] m_Speakers;
        private int m_CurrentSpeaker = 0;
        public bool IsEmpty => m_Speakers.Length == 0;
        public static event Action ConversationEnd;
        public static event Action ConversationStart;

        private void Awake()
        {
            if (m_Speakers != null && m_Speakers.Length > 0)
                Speaker.MessageExpired += OnNewMessage;
            
        }
        public void StartConversation()
        {
            if (m_Speakers!= null && m_Speakers.Length > 0)
            {
                ConversationStart?.Invoke();
                OnNewMessage();
            }
            else
                ConversationEnd?.Invoke();

        }
        public void Forward()
        {
            Speaker.MessageExpired?.Invoke();
        }
        private void OnNewMessage()
        {
            if (m_Speakers != null && m_Speakers.Length > 0)
            {
                if (m_CurrentSpeaker >= m_Speakers.Length)
                {
                    Speaker.MessageExpired -= OnNewMessage;
                    ConversationEnd?.Invoke();
                    return;
                }
                m_Speakers[m_CurrentSpeaker].Say();
                m_CurrentSpeaker++;
                
            }
        }
    }
}

