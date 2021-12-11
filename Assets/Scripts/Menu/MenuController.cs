using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button LogoBtn,
                    StartButton;
    public GameObject BunnySelectorPanel,
                    logoObject;

    void Start()
    {
        LogoBtn.onClick.AddListener(enableBunnySelector);
        StartButton.onClick.AddListener(loadGame);
        setPlayerSprite();
    }

    void enableBunnySelector(){
        BunnySelectorPanel.SetActive(true);
    }

    void loadGame(){
        SceneManager.LoadScene(1);
    }

    public void setPlayerSprite(Sprite spriteImage = null){
        if(spriteImage != null){
            logoObject.GetComponent<Image>().sprite = spriteImage;
            Manager.GameManagerObj.playerSprite = spriteImage;
        }else{
            logoObject.GetComponent<Image>().sprite = Manager.GameManagerObj.playerSprite;
            Manager.GameManagerObj.playerSprite = Manager.GameManagerObj.playerSprite;
        }
    }
}
