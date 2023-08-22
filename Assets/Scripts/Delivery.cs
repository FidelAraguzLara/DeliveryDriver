using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private bool m_HasPackage;
    [SerializeField] private float m_DestroyCountdown;
    [SerializeField] private Color32 m_HasPackagerColor = new Color32(1, 0, 0, 1);
    [SerializeField] private Color32 m_HasNoPackagerColor = new Color32(1, 1, 1, 1);

    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionConfirmed");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && !m_HasPackage)
        {
            Debug.Log("Package picked up");
            m_HasPackage = true;
            m_SpriteRenderer.color = m_HasPackagerColor;
            Destroy(collision.gameObject, m_DestroyCountdown);
        }
        
        if (collision.tag == "Costumer" && m_HasPackage)
        {
            Debug.Log("Package delivered");
            m_HasPackage = false;
            m_SpriteRenderer.color = m_HasNoPackagerColor;
        }
    }

}
