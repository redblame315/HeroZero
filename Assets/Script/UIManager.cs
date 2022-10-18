using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public UIScreen characterUIScreen;
    public UIScreen mainUIScreen;

    private PlayerInfo playerInfo;

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameManager.instance.playerInfo;
        if (playerInfo.level == 0)
            characterUIScreen.Focus();
        else
            mainUIScreen.Focus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
