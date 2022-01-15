using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    public Button pauseBtn,
                    playBtn,
                    restartBtn,
                    homeBtn;
    public Text scoreBoard;
    int score=0;
    public GameObject selectMenu;

    private void Start() {
        pauseBtn.onClick.AddListener(pausePlayGame);
        playBtn.onClick.AddListener(startPauseGame);
        restartBtn.onClick.AddListener(restartGame);
        homeBtn.onClick.AddListener(returnHome);
        AddScore();
    }

    void enableTimeScale(){
        Time.timeScale = 1;
    }

    void pausePlayGame(){
        if(Time.timeScale == 1){
            Time.timeScale = 0;
            Debug.Log("Scale Time Set to 0");
            selectMenu.SetActive(true);
        }
    }

    void startPauseGame(){
        enableTimeScale();
        selectMenu.SetActive(false);
    }

    void restartGame(){
        enableTimeScale();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void returnHome(){
        enableTimeScale();
        SceneManager.LoadScene(0);
    }

    public void AddScore(int scoreVal=0){
        score += scoreVal;
        scoreBoard.text = "Score : "+score;
    }
}
