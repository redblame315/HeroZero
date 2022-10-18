using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public string nickName = "";
    public int level = 0;
    public int strength = 0;
    public int dodge = 0;    
    public string skin = "";
    public int mission = 0;
    public List<int> itemState = new List<int>();
    public PlayerInfo()
    {        
    }
   
    public void Save()
    {
        PlayerPrefs.SetString("nickName", nickName);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("strength", strength);
        PlayerPrefs.SetInt("dodge", dodge);
        PlayerPrefs.SetString("skin", skin);
        PlayerPrefs.SetInt("mission", mission);
        PlayerPrefs.SetInt("itemStateCount", itemState.Count);
        for(int i = 0; i < itemState.Count; i++)
            PlayerPrefs.SetInt("itemState" + i.ToString(), itemState[i]);
    }

    public void Load()
    {
        nickName = PlayerPrefs.GetString("nickName", "");
        level = PlayerPrefs.GetInt("level", 0);
        strength = PlayerPrefs.GetInt("strength", 0);
        dodge = PlayerPrefs.GetInt("dodge", 0);
        skin = PlayerPrefs.GetString("skin", "");
        mission = PlayerPrefs.GetInt("mission", 0);

        int itemStateCount = PlayerPrefs.GetInt("itemStateCount", 0);
        for (int i = 0; i < itemStateCount; i++)
        {
            int state = PlayerPrefs.GetInt("itemState" + i.ToString(),0);
            itemState.Add(state);
        }
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerInfo playerInfo = new PlayerInfo();

    private void Awake()
    {
        instance = this;
        playerInfo.Load();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            playerInfo.level = 0;
            playerInfo.Save();
            UIManager.instance.characterUIScreen.Focus();
        }
    }
}
