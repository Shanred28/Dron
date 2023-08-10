using TMPro;
using UnityEngine;

namespace Hacaton
{
    public class CreditsUpdate : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_Credits;

        private void Awake()
        {
            UpgradesPanel.OnUserInteractedWithSlot += UpdateCredits;
            UpdateTextCredits();
        }

        private void UpdateCredits(CommonUpgrade upgrade)
        {
            Inventory.Instance.AddMoney(-upgrade.NextCost);
            UpdateTextCredits();
        }
        private void UpdateTextCredits()
        {
            m_Credits.text = $"Кредиты: {Inventory.Instance.Money}";
        }
    }
}

