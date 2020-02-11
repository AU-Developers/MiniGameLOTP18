using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Model playerData = new Model();
    [SerializeField] private Minigame game = new Minigame();
    

    private void Start()
    {
        game.chance = game.setChance;
    }

    void Update()
    {
        if (game.playerBetted) // Player bet button, has to have more money than the current bet
        {
            if (playerData.money >= game.bet && game.bet > 0 && !game.hasPool)
            {
                playerData.money -= game.bet;
                game.hasPool = true;
                print("I've bet " + game.bet);
                game.pool = game.bet;
            }
            game.playerBetted = false;
        }

        if (game.hasPool) // Player has to bet first before he is able to guess
        {
            if (game.streak < game.setCount)
            {
                if (game.guessed) // Player guessed a button
                {
                    if (Random.Range(0.0001f, 100f) <= game.chance) // Guessed correctly, chance can be rigged (0 can never win, 100 can always win)
                    {
                        game.currentCorrectInSet++;
                        Debug.Log("Button correct, " + game.currentCorrectInSet + '/' + game.correctNeededInSet + " buttons guessed correctly.");
                        if (game.currentCorrectInSet == game.correctNeededInSet - 1)
                        {
                            game.chance = 100;
                        }
                        if (game.currentCorrectInSet >= game.correctNeededInSet) // Player guessed all correct in the set
                        {
                            game.streak++;
                            game.chance = game.setChance;
                            Debug.Log("Set guessed correctly, streak x" + game.streak);
                            game.rewards = game.pool * game.streak;
                            game.currentCorrectInSet = 0;
                        }
                    }
                    else // Guessed incorrectly
                    {
                        Debug.LogWarning("Button incorrect, streak x0");
                        game.rewards = 0;
                        game.pool = 0;
                        game.streak = 0;
                        game.hasPool = false;
                        game.currentCorrectInSet = 0;
                    }

                    game.guessed = false;
                }
            }
            else
            {
                game.hasPool = false;
                game.claimedReward = true;
                Debug.Log("You won the minigame! Your reward is: " + game.rewards);
            }
        }
        else if (game.claimedReward)
        {
            playerData.money += game.rewards;
            print("Money claimed: " + game.rewards + "\nTotal Money: " + playerData.money);
            game.streak = 0;
            game.rewards = 0;
            game.currentCorrectInSet = 0;
            game.hasPool = false;
            game.claimedReward = false;
        }
    }

    public void bet()
    {
        game.playerBetted = true;
    }

    public void guess()
    {
        game.guessed = true;
    }

    public void claimReward()
    {
        game.hasPool = false;
        game.claimedReward = true;
    }
}
