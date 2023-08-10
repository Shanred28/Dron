using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class HubNavigationPanel : SelectableNavigationUI
    {
        [SerializeField] private Selectable3D[] m_Selectables3D;
        [SerializeField] private Button m_RightBtn;
        [SerializeField] private Button m_LeftBtn;


        private ISelectable m_NewSelectable;
        protected new void Start()
        {
            m_RightBtn.onClick.AddListener(OnRightButtonClick);
            m_LeftBtn.onClick.AddListener(OnLeftButtonClick);
            m_Selectables = m_Selectables3D;
            base.Start();
        }

        private void OnLeftButtonClick()
        {
            m_SelectedIndex--;
            if (m_SelectedIndex < 0) 
                m_SelectedIndex = m_Selectables.Length - 1;
            OnNewSelection();
        }

        private void OnRightButtonClick()
        {
            m_SelectedIndex++;
            if (m_SelectedIndex == m_Selectables.Length)
                m_SelectedIndex = 0;
            OnNewSelection();
        }

        private void OnNewSelection()
        {
            m_NewSelectable = m_Selectables[m_SelectedIndex];
            m_CurrentSelectable.RemoveSelection();
            m_CurrentSelectable = m_NewSelectable;
            m_CurrentSelectable.SelectItem();
        }

        public void SelectChosenItem()
        {
            (m_CurrentSelectable as MenuItem3D).ExecuteCommand();
        }

    }
}

