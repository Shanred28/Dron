using UnityEngine;

namespace Hacaton
{
    public class Selectable3D : MonoBehaviour, ISelectable
    {
        [SerializeField] private Highlight m_Highlighter;
        [SerializeField] private GameObject m_CloseUpVirtualCamera;
        private bool m_IsSelected;
        public bool IsSelected { set => m_IsSelected = value; }

        public virtual void SelectItem()
        {
            m_Highlighter.ToggleHighlight(true);
            if (m_CloseUpVirtualCamera)
                m_CloseUpVirtualCamera.SetActive(true);
            m_IsSelected = true;
            //Debug.Log($"Я {name}. Меня выбрали");
        }

        public void RemoveSelection()
        {
            m_Highlighter.ToggleHighlight(false);
            if (m_CloseUpVirtualCamera)
                m_CloseUpVirtualCamera.SetActive(false);
            m_IsSelected = false;
            //Debug.Log($"Я {name}. Меня покинули");
        }
    }
}

