using UnityEngine;

namespace Hacaton
{
    public class StartConversation : MonoBehaviour
    {
        [SerializeField] private Conversation m_Conversation;
        [SerializeField] private GameObject m_MessagePanel;
        private void Start()
        {
            if (!m_Conversation.IsEmpty)
                m_MessagePanel.SetActive(true);
            m_Conversation.StartConversation();
        }
    }
}

