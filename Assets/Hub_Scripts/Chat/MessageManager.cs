using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Hacaton.Speaker;

namespace Hacaton
{
    public class MessageManager : SingletonBase<MessageManager>
    {
        [SerializeField] private TMP_Text m_SpeakerNickname;
        [SerializeField] private TMP_Text m_Message;
        [SerializeField] private Image m_SpeakerAvatar;

        private void OnEnable()
        {
            Conversation.ConversationStart += OnConversationStart;
            Conversation.ConversationEnd += OnConversationEnd;
        }

        private void OnConversationEnd()
        {
            gameObject.SetActive(false);
            Conversation.ConversationEnd -= OnConversationEnd;
        }

        private void OnConversationStart()
        {
            gameObject.SetActive(true);
            Conversation.ConversationStart -= OnConversationStart;
        }

        private void OnDestroy()
        {
            Conversation.ConversationStart -= OnConversationStart;
            Conversation.ConversationEnd -= OnConversationEnd;
        }

        public static void DisplayMessage(Speaker speaker, Speech message)
        {
            Instance.m_SpeakerNickname.text = speaker.Nickname;
            Instance.m_SpeakerAvatar.sprite = speaker.Avatar;
            Instance.m_Message.text = message.Text;
        }



    }
}

