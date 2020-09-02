using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchButton : MonoBehaviour
{
    public Transform m_btnMesh, m_upTransform, m_downTransform;

    public UnityEvent m_btnPressed;
    public UnityEvent m_btnReleased;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_btnMesh.position = m_downTransform.position;

            m_btnPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            m_btnMesh.position = m_upTransform.position;

            m_btnReleased.Invoke();
        }
    }
}
