using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // Use this for initialization
   public GameObject MenuOption;
   public static GameObject OptMenu;
   void Start () {
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void Play() {
        AudioManager.Instance.PlayMusic(0);
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        if(MenuOption)
            MenuOption.SetActive(true);
        gameObject.SetActive(false);
    }
    public void MainGameMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void LoadCurrentScene()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Additive);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
