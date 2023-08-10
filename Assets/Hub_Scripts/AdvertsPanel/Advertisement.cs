using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class Advertisement : Slot<FarmLevel>
    {
        [SerializeField] protected TMP_Text m_Location;
        [SerializeField] protected TMP_Text m_Reward;
        [SerializeField] protected TMP_Text m_CargoType;
        [SerializeField] protected Button m_AcceptBtn;
        [SerializeField] protected Button m_RejectBtn;
        private FarmLevel m_Level;
        private void Awake()
        {
            if (m_AcceptBtn)
                m_AcceptBtn.onClick.AddListener(OnAccept);
            if (m_RejectBtn)
                m_RejectBtn.onClick.AddListener(OnReject);
        }

        private void OnReject()
        {
            m_Level.SetRejected(true);
            OnUserInteraction?.Invoke(this);
        }

        private void OnAccept()
        {
            m_Level.IsAddedToMap = true;
            OnUserInteraction?.Invoke(this);
        }

        public override void Initialize(FarmLevel level)
        {
            m_Location.text = level.Location;
            m_Reward.text = level.Reward;
            m_CargoType.text = level.Cargo;
            m_Level = level;
        }


    }
}

