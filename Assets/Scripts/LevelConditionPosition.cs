using UnityEngine;

namespace Hacaton
{
    public class LevelConditionPosition : MonoBehaviour
    {
        [SerializeField] private Collider m_TargetPosition;

        private bool m_Reached = false;

        private bool IsTargetPosition = false;

/*        bool ILevelCondition.IsCompleted
        {
            get
            {
                if (IsTargetPosition)
                {
                    m_Reached = true;
                    Debug.Log(m_Reached);
                    return m_Reached;
                }
                else
                {
                    m_Reached = false;
                    return m_Reached;
                }
            }
        }*/

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.GetComponent<Dron>() != null)
                IsTargetPosition = true;
        }
    }
}

