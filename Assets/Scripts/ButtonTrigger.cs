using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private GateAnimated gate;

    private bool canOpen = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            canOpen = true;
            Debug.Log(canOpen);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            canOpen = false;
            Debug.Log(canOpen);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && canOpen)
        {

            if (gate.GetOpen() == false)
            {
                gate.OpenGate();
            }
            else
            {
                gate.CloseGate();
            }
        }
        
    }


    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player touched");
            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("G");
                update();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void update()
    {
        if (gate.GetOpen() == true)
        {
            Debug.Log("true");
            gate.OpenGate();
        }
        else
        {
            Debug.Log("false");
            gate.CloseGate();
        }
    }

    */
} 
