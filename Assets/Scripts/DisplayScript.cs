using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
	[SerializeField] Text moneytext;
	[SerializeField] Text claimtext;
	[SerializeField] Button[] buttons;
	[SerializeField] Button betButton;
	[SerializeField] Button claimButton;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		moneytext.text = "Money: " +  GameController._instance._playerData.money;
		claimtext.text = "Claim: " + (GameController._instance._game.pool * GameController._instance._game.streak);
    }
	public void InteractableButton(bool IsInteracable)
	{
		for (int x = 0 ; x < buttons.Length; x++)
		{
			buttons[x].interactable = IsInteracable;
		}
	}
	public void BetButtonInteract(bool IsInteracable)
	{
		betButton.interactable = IsInteracable;
	}
	public void ClaimButtonInteract(bool IsInteracable)
	{
		claimButton.interactable = IsInteracable;
	}


}
