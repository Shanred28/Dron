using UnityEngine;
using System;

namespace Hacaton
{
    public class LevelChoiceControllerUI : SelectableNavigationUI
    {
        [SerializeField] private SelectableImage[] m_SelectableImages;
        [SerializeField] private PointerClickHold m_ForwardBtn;
        [SerializeField] private PointerClickHold m_BackwardBtn;
        public static event Action<ISelectable> LevelChanged;

        protected new void Start()
        {
            m_Selectables = m_SelectableImages;
            base.Start();
        }
        private void Update()
        {
            ISelectable newLevel = null;
            /*if (m_ForwardBtn.IsHold)
            {
                if (m_Fwd.TryPop(out newLevel))
                {
                    m_Bwd.Push(newLevel);
                }
            }
            if (m_BackwardBtn.IsHold)
            {
                if (m_Bwd.TryPop(out newLevel))
                {
                    m_Fwd.Push(newLevel);
                }
            }*/
            if (newLevel != null && newLevel != m_CurrentSelectable)
            {
                m_CurrentSelectable.RemoveSelection();
                m_CurrentSelectable = newLevel;
                m_CurrentSelectable.SelectItem();
            }
        }

    }
}

