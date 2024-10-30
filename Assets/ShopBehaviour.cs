using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehaviour : MonoBehaviour
{
    public PlayerScoreSystem PlayerScore;

    public void ButClikerUpgrade()
    {
        //If the player score is above 10
        if (PlayerScore.GetPlayerScoreValue() >= 10)
        {
    
         //Remove the amount of score for the upgrade
            PlayerScore.RemoveScore(10);
         //Increase their multiplier by one
         PlayerScore.IncreaseMultiplier();
        }
    }
}