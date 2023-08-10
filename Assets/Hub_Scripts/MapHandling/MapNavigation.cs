using UnityEngine;

namespace Hacaton
{
    public class MapNavigation : MonoBehaviour
    {
        [SerializeField] private GameObject m_Camera;
        [SerializeField] private SpriteRenderer m_Map;
        [SerializeField] private float m_CameraVelocity;
        [SerializeField] private float m_Threshold;
        private Vector3 m_Goal;
        private bool m_IsMoving;

        private void Awake()
        {
            MapLevel.LevelSelected += OnSelectedLevelChange;
        }

        private void Update()
        {
            if (!m_IsMoving) return;
            if ((m_Goal - m_Camera.transform.position).normalized.magnitude <= m_Threshold)
            {
                m_Camera.transform.position = m_Goal;
                m_IsMoving = false;
                return;
            }
            m_Camera.transform.position = Vector3.MoveTowards(m_Camera.transform.position, m_Goal, m_CameraVelocity * Time.deltaTime);

        }
        private void OnSelectedLevelChange(MapLevel newLevel)
        {
            m_Goal = DefineCameraPosition(newLevel);
            m_IsMoving = true;
        }

        private Vector3 DefineCameraPosition(MapLevel newLevel)
        {
            var camHeight = Camera.main.orthographicSize;
            var ratio = Camera.main.aspect;
            float camWidth = camHeight * ratio;
            var levelPos = newLevel.transform.position;
            float mapWidth = m_Map.size.x;
            float mapHeight = m_Map.size.y;
            Vector3 mapLeftBottomCorner = new Vector3(-mapWidth / 2, -mapHeight / 2, 0);
            Vector3 mapRightBottomCorner = new Vector3(mapWidth / 2, -mapHeight / 2, 0);
            Vector3 mapLeftUpperCorner = new Vector3(-mapWidth / 2, mapHeight / 2, 0);
            var newCamPos = new Vector3(levelPos.x, levelPos.y, m_Camera.transform.position.z);
            var deltaX = levelPos.x - mapLeftBottomCorner.x;
            var deltaY = mapLeftUpperCorner.y - levelPos.y;
            if (deltaX < camWidth)
            {
                newCamPos.x = -camWidth;
            }
            if (deltaY < camHeight)
            {
                newCamPos.y = mapLeftUpperCorner.y - camHeight;
            }
            deltaX = -levelPos.x + mapRightBottomCorner.x;
            deltaY = -mapLeftBottomCorner.y + levelPos.y;
            if (deltaX < camWidth)
            {
                newCamPos.x = mapRightBottomCorner.x - camWidth;
            }
            if (deltaY < camHeight)
            {
                newCamPos.y = -camHeight;
            }
            return newCamPos;
        }
    }

}
