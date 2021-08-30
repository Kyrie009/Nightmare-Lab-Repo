using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : Singleton<BackGroundManager>
{
    public Sprite[] backGroundList;
    // Start is called before the first frame update
    void Start()
    {
        DefaultBackground();
    }
    public void DefaultBackground()
    {
        this.GetComponent<Image>().sprite = backGroundList[0];
    }
    public void CombatBackground()
    {
        this.GetComponent<Image>().sprite = backGroundList[1];
    }

    
}
