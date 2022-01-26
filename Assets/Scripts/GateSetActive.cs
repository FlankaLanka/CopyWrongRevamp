using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSetActive : MonoBehaviour
{
    public void OpenGate()
    {
        gameObject.SetActive(false);
    }
    public void CloseGate()
    {
        gameObject.SetActive(true);
    }
}
