using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunnySelector : MonoBehaviour
{
    public Button bunny1, 
                bunny2;
    public MenuController menu;
    private void OnEnable() {
        bunny1.onClick.AddListener(delegate{bunnySelect(1);});
        bunny2.onClick.AddListener(delegate{bunnySelect(2);});        
    }

    private void OnDisable() {
        bunny1.onClick.RemoveAllListeners();
        bunny2.onClick.RemoveAllListeners();
    }

    public void bunnySelect(int index){
        if(index == 1){
            menu.setPlayerSprite(Manager.GameManagerObj.bunny1);
            Manager.GameManagerObj.playerTypeIndex = 0;
        }else{
            menu.setPlayerSprite(Manager.GameManagerObj.bunny2);
            Manager.GameManagerObj.playerTypeIndex = 1;
        }
        gameObject.SetActive(false);
    }
}
