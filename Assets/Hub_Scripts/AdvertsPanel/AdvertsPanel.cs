using UnityEngine;

namespace Hacaton
{
    public class AdvertsPanel : SlotPanel<FarmLevel, Advertisement>
    {
        [SerializeField] private Levels m_Levels;

        protected override void FillAdverts()
        {
            m_SlotObjects = m_Levels.AllAvailableFarmLevels;
            base.FillAdverts();
        }

    }
}
