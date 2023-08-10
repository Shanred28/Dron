using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class SelectableImage : MonoBehaviour, ISelectable
    {

        private Color m_UnselectedColor;
        [SerializeField] private Color m_SelectedColor;
        [SerializeField] private Episode m_EpisodeToLoad;

        private Image m_SelectedImage;
        public GameObject Selected => m_SelectedImage.gameObject;

        private bool m_IsSelected;
        public bool IsSelected { set => m_IsSelected = value; }

        public Episode EpisodeToLoad => m_EpisodeToLoad;

        private void Start()
        {
            m_SelectedImage = GetComponent<Image>();
            m_UnselectedColor = m_SelectedImage.color;
        }

        public void SelectItem()
        {
            m_SelectedImage.color = m_SelectedColor;
            m_IsSelected = true;
        }

        public void RemoveSelection()
        {
            m_SelectedImage.color = m_UnselectedColor;
            m_IsSelected = false;
        }
    }
}

