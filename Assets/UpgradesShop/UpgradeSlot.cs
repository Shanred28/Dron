using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class UpgradeSlot : Slot<CommonUpgrade>
    {
        [SerializeField] private TMP_Text m_UpgradeName;
        [SerializeField] private TMP_Text m_Cost;
        [SerializeField] private TMP_Text m_Effect;
        [SerializeField] private TMP_Text m_NextLevel;
        [SerializeField] private Image m_Icon;
        [SerializeField] private Button m_BuyButton;
        //public CommonUpgrade UpgradeInSlot { get; private set; }
        private void Awake()
        {
            m_BuyButton.onClick.AddListener(OnBuy);
        }

        private void OnBuy()
        {
            OnUserInteraction?.Invoke(this);
        }

        public override void Initialize(CommonUpgrade upgrade)
        {
            m_UpgradeName.text = upgrade.UpgradeName;
            m_Cost.text = $"Цена: {upgrade.NextCost}";
            string effectType = upgrade.GetEffectType();
            m_Effect.text = $"{effectType}:+{upgrade[upgrade.CurrentLevel + 1]}";
            m_Icon.sprite = upgrade.UpgradeIcon;
            var next = upgrade.CurrentLevel + 1;
            if (next > upgrade.MaximumLevel)
            {
                m_NextLevel.text = "max";
                m_NextLevel.color = Color.gray;
                m_Cost.gameObject.SetActive(false);
                m_BuyButton.interactable = false;
                return;
            }
            m_NextLevel.text = $"След.уровень: {upgrade.CurrentLevel + 1}";
            m_CurrentOccupant = upgrade;
        }
    }
}

