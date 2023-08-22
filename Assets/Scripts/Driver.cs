using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float m_SteerSpeed = 150f;
    [SerializeField] private float m_MoveSpeed = 10f;
    [SerializeField] private float m_SpeedBuff = 15.0f;
    [SerializeField] private float m_SpeedDeBuff = 5.0f;
    [SerializeField] private float m_SpeedBuffDuration = 3.0f;

    private bool m_HasSpeedBuff = false;
    private bool m_HasSpeedDeBuff = false;

    void Update()
    {
        if(m_HasSpeedBuff == true)
        {
            float a_SteerAmount = Input.GetAxis("Horizontal") * (m_SteerSpeed * Time.deltaTime);
            float a_SpeedAmount = Input.GetAxis("Vertical") * (m_SpeedBuff * Time.deltaTime);

            transform.Rotate(0, 0, -a_SteerAmount);
            transform.Translate(0, a_SpeedAmount, 0);
        }
        else if(m_HasSpeedDeBuff == true) 
        {
            float a_SteerAmount = Input.GetAxis("Horizontal") * (m_SteerSpeed * Time.deltaTime);
            float a_SpeedAmount = Input.GetAxis("Vertical") * (m_SpeedDeBuff * Time.deltaTime);

            transform.Rotate(0, 0, -a_SteerAmount);
            transform.Translate(0, a_SpeedAmount, 0);
        }
        else
        {
            float a_SteerAmount = Input.GetAxis("Horizontal") * (m_SteerSpeed * Time.deltaTime);
            float a_SpeedAmount = Input.GetAxis("Vertical") * (m_MoveSpeed * Time.deltaTime);

            transform.Rotate(0, 0, -a_SteerAmount);
            transform.Translate(0, a_SpeedAmount, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Buff")
        {
            m_HasSpeedBuff = true;
            StartCoroutine(SpeedBuffCoolDown());
        }

        if(collision.tag == "DeBuff")
        {
            m_HasSpeedDeBuff = true;
            StartCoroutine(SpeedDeBuffCoolDown());
        }
    }

    IEnumerator SpeedBuffCoolDown()
    {
        yield return new WaitForSeconds(m_SpeedBuffDuration);
        m_HasSpeedBuff = false;
    }

    IEnumerator SpeedDeBuffCoolDown()
    {
        yield return new WaitForSeconds(m_SpeedBuffDuration);
        m_HasSpeedDeBuff = false;
    }
}
