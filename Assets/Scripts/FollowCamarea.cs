using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamarea : MonoBehaviour
{
    [SerializeField] GameObject m_Car;

    private void LateUpdate()
    {
        transform.position = m_Car.transform.position + new Vector3(0, 0 , -10);
    }
}
