using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimShoot : MonoBehaviour
{
    public GameObject m_prefabFireball;
    public float m_shootForce;
    public Transform m_spawnPoint;

    public ShotCounter m_scScript;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject fireball = Instantiate(m_prefabFireball, m_spawnPoint.position, m_spawnPoint.rotation);
            fireball.GetComponent<Rigidbody>().AddForce(m_spawnPoint.forward * m_shootForce);
            Destroy(fireball, 5);

            m_scScript.m_numShots++;
            m_scScript.UpdateDisplay();
        }
    }
}
