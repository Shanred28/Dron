using UnityEngine;

namespace Hacaton
{
    public abstract class SelectableNavigationUI : MonoBehaviour
    {
        [SerializeField] private int m_DefaultSelectedIndex;
        protected ISelectable[] m_Selectables;
        protected ISelectable m_CurrentSelectable;
        protected int m_SelectedIndex;
        protected void Start()
        {
            if (m_DefaultSelectedIndex < 0 || m_DefaultSelectedIndex >= m_Selectables.Length)
                Debug.LogError($"Specified default selected index is out of allowable range ({0},{m_Selectables.Length - 1})");
            m_CurrentSelectable = m_Selectables[m_DefaultSelectedIndex];
            m_SelectedIndex = m_DefaultSelectedIndex;
            m_CurrentSelectable.SelectItem();
        }
    }
}

