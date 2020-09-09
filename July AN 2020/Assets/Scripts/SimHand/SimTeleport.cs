using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimTeleport : MonoBehaviour
{
    public LayerMask m_validLayers;
    public LineRenderer m_myLine;

    private Vector3 m_hitPoint;
    private bool m_canTeleport;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            //Raycast
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, 25, m_validLayers))
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
        else if(Input.GetKeyUp(KeyCode.T) && m_canTeleport)
        {
            transform.position = m_hitPoint;
            m_canTeleport = false;
            m_myLine.enabled = false;
        }
    }
}
