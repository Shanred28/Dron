using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class Highlight : MonoBehaviour
    {
        [SerializeField] private List<Renderer> m_Renderers;
        [SerializeField] private Color m_Color = Color.white;
        [SerializeField] private float m_EmissionIntensity = 1.0f;

        private List<Material> m_Materials;

        private void Awake()
        {
            m_Materials = new List<Material>();
            foreach (var renderer in m_Renderers)
            {
                m_Materials.AddRange(new List<Material>(renderer.materials));
            }
        }

        public void ToggleHighlight(bool val)
        {
            if (val)
            {
                foreach (var material in m_Materials)
                {
                    material.EnableKeyword("_EMISSION");
                    material.SetColor("_EmissionColor", m_Color * m_EmissionIntensity);

                }
            }
            else
            {
                foreach (var material in m_Materials)
                {
                    material.DisableKeyword("_EMISSION");
                }
            }
        }
    }
}

