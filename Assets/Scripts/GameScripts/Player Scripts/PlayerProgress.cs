using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public GameObject gameplayUI;
    public GameObject youWonScreen;

    public List<PlayerProgressLevel> levels;

    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;
    public Animator animator;

    private int _levelValue = 0;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private void Update()
    {
        if(_levelValue != 10) return;
        PlayerWon();
    }

    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel = levels[_levelValue];
        _experienceTargetValue = currentLevel.experienceForNextLevel;
        GetComponent<FireballCaster>().damage = currentLevel.fireballDamage;
        GetComponent<GrenadeCaster>().damage = currentLevel.grenadeDamage;

        if(currentLevel.grenadeDamage < 0)
            GetComponent<GrenadeCaster>().enabled = false;
        else 
            GetComponent<GrenadeCaster>().enabled = true;
    }

    private void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue/_experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }

    private void PlayerWon()
    {
        gameplayUI.SetActive(false);
        youWonScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("victory");
    }
}
