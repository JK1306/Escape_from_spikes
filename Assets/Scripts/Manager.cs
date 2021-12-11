using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Sprite bunny1,
                bunny2;
    public Sprite playerSprite;
    public int playerTypeIndex=0;
    static Manager gameManager;
    public static Manager GameManagerObj{
        get{
           return gameManager;             
        }
    }
    void Start()
    {
        if(gameManager != null){
            Destroy(this);            
        }else{
            gameManager = this;
            DontDestroyOnLoad(this);
        }
        playerSprite = bunny1;
    }
}
