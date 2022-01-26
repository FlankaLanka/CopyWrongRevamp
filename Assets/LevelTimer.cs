using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public GameObject TimerText;
    public float totalTime;

    private float timer;

    private GameObject player;
    private GameObject losePanel;
    private void Awake()
    {
        losePanel = GameObject.Find("EndCanvas").transform.Find("LosePanel").gameObject;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float timeLeft = totalTime - timer;

        if(!losePanel.activeInHierarchy)
        {
            if (timeLeft <= 0)
            {
                TimerText.GetComponent<Text>().text = "Time's Up!";
                player.SetActive(false);
                losePanel.SetActive(true);
            }
            else
            {
                TimerText.GetComponent<Text>().text = (totalTime - timer).ToString("F2");
                timer += Time.deltaTime;
            }
        }
    }
}
