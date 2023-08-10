using System;
using UnityEngine;

namespace Hacaton
{
    public class MenuItem3D : Selectable3D
    {
        [SerializeField] private string m_MenuItemName;
        [SerializeField] private string m_MenuItemHelp;
        [SerializeField] private Command m_Command;

        public static event Action<string,string> OnSelectItem;

        public override void SelectItem()
        {
            base.SelectItem();
            OnSelectItem(m_MenuItemName, m_MenuItemHelp);
        }

        public void ExecuteCommand()
        {
            m_Command.Execute();
        }
    }
}

