using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleport : MonoBehaviour
{
    public string m_buttonName;
    public Transform m_VRRoot;

    public LayerMask m_validLayers;
    public LineRenderer m_myLine;

    private Vector3 m_hitPoint;
    private bool m_canTeleport;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(m_buttonName))
        {
            //Raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 25, m_validLayers))
            {
                m_hitPoint = hit.point;
                m_myLine.SetPosition(0, transform.position);
                m_myLine.SetPosition(1, m_hitPoint);

                m_canTeleport = true;
                m_myLine.enabled = true;
            }
            else
            {
                m_canTeleport = false;
                m_myLine.enabled = false;
            }
        }
        else if (Input.GetButtonUp(m_buttonName) && m_canTeleport)
        {
            m_VRRoot.position = m_hitPoint;
            m_canTeleport = false;
            m_myLine.enabled = false;
        }
    }
}
