using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Minigame
{
    public int bet;
    [HideInInspector] public int pool, rewards;
    public int correctNeededInSet = 3, setCount = 5;
    public float setChance = 30;

    [HideInInspector] public float chance;
    [HideInInspector] public int currentCorrectInSet, streak = 0;

    [HideInInspector] public bool playerBetted, guessed, claimedReward;
    [HideInInspector] public bool hasPool;
}
