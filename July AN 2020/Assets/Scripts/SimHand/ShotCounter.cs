using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public int m_numShots;
    public Text m_countDisplay;

    public void UpdateDisplay()
    {
        m_countDisplay.text = "Shots Fired:" + m_numShots;
    }
}
