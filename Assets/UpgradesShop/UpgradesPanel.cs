using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class UpgradesPanel : SlotPanel<CommonUpgrade, UpgradeSlot>
    {
        //[SerializeField] private CommonUpgrade[] m_Upgrades;
        public static event Action<CommonUpgrade> OnUserInteractedWithSlot;
        protected override void FillAdverts()
        {
            var list = new List<CommonUpgrade>();
            foreach(var slot in m_SlotObjects)
            {
                if (slot.IsAvailable)
                    list.Add(slot);

            }
            m_SlotObjects = list.ToArray();
            base.FillAdverts();
        }
        protected override void OnUserAdvertsInteraction(Slot<CommonUpgrade> advert)
        {
            OnUserInteractedWithSlot?.Invoke(advert.CurrentOccupant);
            base.OnUserAdvertsInteraction(advert);
        }
    }
}

