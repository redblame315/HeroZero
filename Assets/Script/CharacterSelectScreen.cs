using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScreen : UIScreen
{
    public static CharacterSelectScreen instance = null;
    public UISprite characterSprite;
    public UILabel skinTypeLabel;
    public NameScreen nameScreen;
    private string[] skinTypeArray = { "Gray", "Brown" };
    private string[] skinNameArray = { "hero1", "hero1_brown" };
    private int skinIndex = 0;

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

    public void SkinPrevButtonClicked()
    {
        skinIndex--;
        if (skinIndex < 0)
            skinIndex = 0;

        characterSprite.spriteName = skinNameArray[skinIndex];
        skinTypeLabel.text = skinTypeArray[skinIndex];
    }

    public void SkinNextButtonClicked()
    {
        skinIndex++;
        if (skinIndex >= skinTypeArray.Length)
        {
            skinIndex = skinTypeArray.Length - 1;
        }

        characterSprite.spriteName = skinNameArray[skinIndex];
        skinTypeLabel.text = skinTypeArray[skinIndex];
    }

    public void NextButtonClicked()
    {
        nameScreen.gameObject.SetActive(true);
    }
    public override void Init()
    { 
    
    }    
}
