using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGate : MonoBehaviour
{
    private float time;
    private Vector3 scaleC;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        scaleC = transform.localScale;
        Debug.Log("NANI");
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0f)
        {
            Debug.Log("AAAAAAAAA");
            scaleC.x -= 0.1f;
            transform.localScale = scaleC;
            time = 0.01f;
        }
        else
        {
            time -= Time.deltaTime;

        }
            Debug.Log(time);
    }
}
