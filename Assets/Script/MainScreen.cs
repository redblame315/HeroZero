using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : UIScreen
{
    public static MainScreen instance = null;
    public UILabel nickNameLabel;
    public UISprite heroSprite;
    public UIProgressBar levelProgressBar;
    public UIProgressBar strengthProgressBar;
    public UIProgressBar dodgeProgressBar;
    public InvEquipment invEquipment;
    public UIItemStorage uIItemStorage;
    public UIButton missionButton;
    public GameObject missionScreen;
    public UISprite missionProgress;
    public float missionDuration = 30;
    GameManager gameManager;
    PlayerInfo playerInfo;

    private void Awake()
    {
        instance = this;
    }
    public override void Init()
    {
        gameManager = GameManager.instance;
        playerInfo = gameManager.playerInfo;
        EnableMissionButton(playerInfo.mission == 0);        

        UpdatePlayerInfoUI();

        invEquipment.ClearItem();
        uIItemStorage.ClearItem();

        for (int i = 0; i < playerInfo.itemState.Count; i++)
        {
            if (playerInfo.itemState[i] == 1)
                invEquipment.Equip(i);
            else
                uIItemStorage.InitItem(i);
        }
    }

    public void UpdatePlayerInfoUI()
    {
        nickNameLabel.text = playerInfo.nickName;
        heroSprite.spriteName = playerInfo.skin;
        levelProgressBar.value = playerInfo.level / 10.0f;
        strengthProgressBar.value = playerInfo.strength / 10.0f;
        dodgeProgressBar.value = playerInfo.dodge / 10.0f;
    }

    public void MissionButtonClicked()
    {
        StartCoroutine(MissionRoutine());
    }

    void EnableMissionButton(bool enable)
    {
        missionButton.defaultColor = enable ? Color.blue : Color.white;
        missionButton.hover = enable ? Color.blue : Color.white;
        missionButton.pressed = enable ? Color.blue : Color.white;
        missionButton.GetComponent<BoxCollider>().enabled = enable;
        missionButton.gameObject.SetActive(false);
        missionButton.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MissionRoutine()
    {
        missionScreen.SetActive(true);
        missionProgress.fillAmount = 0;
        for (int i = 0; i < missionDuration * 5; i++)
        {
            yield return new WaitForSeconds(.2f);
            missionProgress.fillAmount += 1 / (missionDuration * 5f);
        }

        playerInfo.level++;
        playerInfo.mission = 1;
        playerInfo.Save();
        EnableMissionButton(false);
        missionScreen.SetActive(false);
        UpdatePlayerInfoUI();
    }


}
