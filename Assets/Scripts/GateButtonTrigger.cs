using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButtonTrigger : MonoBehaviour
{
    [SerializeField] private GateSetActive gate;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gate.OpenGate();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            gate.CloseGate();
        }
    }
}
