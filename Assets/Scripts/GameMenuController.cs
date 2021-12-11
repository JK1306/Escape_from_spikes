using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    public Button pauseBtn,
                    restartBtn;
    public Sprite playBtnSprite,
                    pauseBtnSprite;
    public Text scoreBoard;
    int score=0;

    private void Start() {
        pauseBtn.onClick.AddListener(pausePlayGame);
        AddScore();
    }

    void pausePlayGame(){
        if(Time.timeScale == 1){
            Time.timeScale = 0;
            Debug.Log("Scale Time Set to 0");
            pauseBtn.GetComponent<Image>().sprite = playBtnSprite;
        }else{
            Time.timeScale = 1;
            Debug.Log("Scale Time Set to 1");
            pauseBtn.GetComponent<Image>().sprite = pauseBtnSprite;
        }
    }

    public void AddScore(int scoreVal=0){
        score += scoreVal;
        scoreBoard.text = "Score : "+score;
    }
}
