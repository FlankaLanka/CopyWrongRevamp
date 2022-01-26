using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButtonTriggerAnimated : MonoBehaviour
{
    [SerializeField] private GateAnimated gate;

    public GameObject a; // _?_ -> null

    public Transform b;



    //
    private void Start()
    {
        a = GameObject.Find("Gate_0");
        a = gameObject;

        b = gameObject.transform;
        a = transform.gameObject;
    }
    //

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