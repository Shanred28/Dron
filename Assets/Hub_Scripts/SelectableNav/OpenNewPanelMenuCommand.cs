using UnityEngine;

namespace Hacaton
{
    public class OpenNewPanelMenuCommand : Command
    {
        [SerializeField] private GameObject m_NewPanel;
        [SerializeField] private GameObject m_ClosePanel;
        public override void Execute()
        {
            if (m_NewPanel)
                m_NewPanel.SetActive(true);
            if (m_ClosePanel)
                m_ClosePanel.SetActive(false);
        }
    }
}

