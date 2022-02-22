using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BackgroundElement : MonoBehaviour
    {
        [Range(0.0f, 4.0f)]
        [SerializeField] private float m_ParalaxPower;

        [SerializeField] private float m_TextureScale;

        private Material m_BackMaterial;
        private Vector2 m_InitialOffset;

        private void Start()
        {
            m_BackMaterial = GetComponent<MeshRenderer>().material;
            m_InitialOffset = Random.insideUnitCircle;
            m_BackMaterial.mainTextureScale = Vector2.one * m_TextureScale;
        }

        private void Update()
        {
            Vector2 offset = m_InitialOffset;

            offset.x += transform.position.x / transform.localScale.x / m_ParalaxPower;
            offset.y += transform.position.y / transform.localScale.y / m_ParalaxPower;

            m_BackMaterial.mainTextureOffset = offset;
        }
    }
}