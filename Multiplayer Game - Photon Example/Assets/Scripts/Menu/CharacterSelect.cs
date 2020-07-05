using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public int CurrentHeroId { get; private set; }

    [SerializeField] private Image characterImage;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button prevBtn;

    private List<CharacterPlayer> characterPlayers;

    public void CreateList(List<CharacterPlayer> characterPlayers)
    {
        this.characterPlayers = characterPlayers;
        SetPlayer(0);
    }

    private void SetPlayer(int idx)
    {
        CurrentHeroId = idx;
        characterImage.sprite = characterPlayers[CurrentHeroId].uiSprite;
    }

    public void ChangeHeroBtn(bool isNext)
    {
        if (isNext)
            CurrentHeroId = (CurrentHeroId < characterPlayers.Count - 1) ? CurrentHeroId + 1 : 0;
        else
            CurrentHeroId = (CurrentHeroId > 0) ? CurrentHeroId - 1 : characterPlayers.Count - 1;

        SetPlayer(CurrentHeroId);
    }
}
