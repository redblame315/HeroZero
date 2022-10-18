using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameScreen : MonoBehaviour
{
    public static NameScreen instance = null;
    public UIInput nameInput;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseButtonClicked()
    {
        gameObject.SetActive(false);
    }

    public void OkButtonClicked()
    {
        if (nameInput.text == "")
            return;

        PlayerInfo playerInfo = GameManager.instance.playerInfo;
        playerInfo.nickName = nameInput.text;
        playerInfo.level = 1;
        playerInfo.strength = 1;
        playerInfo.dodge = 1;
        playerInfo.mission = 0;
        playerInfo.skin = CharacterSelectScreen.instance.characterSprite.spriteName;

        playerInfo.itemState.Clear();
        for (int i = 0; i < 2; i++)
            playerInfo.itemState.Add(0);

        playerInfo.Save();
        UIManager.instance.mainUIScreen.Focus();
        CloseButtonClicked();
    }
}
