using Hacaton;
using UnityEngine;


namespace Hacaton 
{
    public class ProceedToLevel : MonoBehaviour
    {
        private void Start()
        {
            Conversation.ConversationEnd += OnConversationEnd;
        }

        private void OnConversationEnd()
        {
            LevelSequenceController.Instance.AdvanceLevel();
        }
    }
}

