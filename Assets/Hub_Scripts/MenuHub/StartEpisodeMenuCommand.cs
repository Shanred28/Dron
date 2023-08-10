using UnityEngine;

namespace Hacaton
{
    public class StartEpisodeMenuCommand : Command
    {
        [SerializeField] private Episode m_Episode;
        public override void Execute()
        {
            LevelSequenceController.Instance.StartMission(m_Episode);
        }
    }
}

