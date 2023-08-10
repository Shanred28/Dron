using TMPro;
using UnityEngine;

namespace Hacaton
{
    public class HubInfoPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_NameField;
        [SerializeField] private TMP_Text m_HelpField;

        private void Awake()
        {
            MenuItem3D.OnSelectItem += OnItemSelection;
        }
        private void OnItemSelection(string name, string help)
        {
            m_NameField.text = name;
            m_HelpField.text = $"Подсказка: {help}";
        }
        private void OnDestroy()
        {
            MenuItem3D.OnSelectItem -= OnItemSelection;
        }
    }
}

