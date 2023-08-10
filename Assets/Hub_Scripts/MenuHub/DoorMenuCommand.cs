using UnityEngine;

namespace Hacaton
{
    public class DoorMenuCommand : Command
    {
        public override void Execute()
        {
            Application.Quit();
        }
    }
}

