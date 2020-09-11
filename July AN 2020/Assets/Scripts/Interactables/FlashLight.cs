using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light m_myLight;

    void TriggerDown()
    {
        m_myLight.enabled = !m_myLight.enabled;
    }
}
