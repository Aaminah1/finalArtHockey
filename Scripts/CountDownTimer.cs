using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public float timer;
    public TMP_Text timerSeconds;

    [SerializeField] Object levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        timerSeconds = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
    }

    public void StartGame()//intended to start game after timer ends
    {timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("0");
        if (timer <= 0)
        {
            Debug.Log("Loading scene: " + levelToLoad.name);
            SceneManager.LoadScene(levelToLoad.name);
        }

    }
}
