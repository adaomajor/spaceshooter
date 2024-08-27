using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour {

    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject PauseGameUI;
    [SerializeField] private GameObject Player;

    private string ScoreText;
    private float currentTimeScale;
   
    // Use this for initialization
    void Start () {
        Time.timeScale = 1f;
        GameOverUI.SetActive(false);
        PauseGameUI.SetActive(false);
        ScoreText = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (Player == null)
        {
            GameObject score = GameObject.FindGameObjectWithTag("Score");
            if (score)
            {
                ScoreText = score.GetComponent<Text>().text;
            }

           MainUI.SetActive(false);

            GameOverUI.SetActive(true);
            GameObject Pontuation = GameObject.FindGameObjectWithTag("GameOverKilled");
            if (Pontuation)
            {
                Text PontuationText = Pontuation.GetComponent<Text>();
                PontuationText.text = ScoreText; ;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if (Time.timeScale != 0f)
        {
            AudioManager.Instance.Muisic.Pause();
            AudioManager.Instance.SFX.PlayOneShot(AudioManager.Instance.Sounds[2]);
            currentTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            PauseGameUI.SetActive(true);
        }else
        {
            AudioManager.Instance.Muisic.Play();
            PauseGameUI.SetActive(false);
            Time.timeScale = currentTimeScale;
        }
    }
    public void MainGameMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.Muisic.Stop();
        AudioManager.Instance.PlayMusic(0);
        SceneManager.LoadScene(1);
    }
}
