using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerScoreSystem : MonoBehaviour
{

    //We are making the score private as we want to only interact with it through methods
    private int _playerScore = 0;
    //this is how powerful the players clicks are
    private int _scoreMultiplier = 1;

    // Add the following variable to track the auto-clicker state
    private bool _isAutoClickerActive = false;

    //These are references to our text in the scene
    public TMP_Text multiplierText;
    public TMP_Text scoreText;

    //New variable for auto-clicker
    public int _autoClickAmount;
    public float _autoClickInterval;

    //We can set the initial score of the player here
    private void Start()
    {
        UpdateText();
    }

    //The parameter takes an int to remove from the players score
    public void AddScore()
    {
        _playerScore += 1 * _scoreMultiplier;
        UpdateText();
    }
    
    //The parameter takes an in to remove from the players score
    public void RemoveScore(int scoreToRemove)
    {
        _playerScore -= scoreToRemove;
    }

    //This increases the player multiplier
    public void IncreaseMultiplier()
    {
        _scoreMultiplier++;
        UpdateText();
    }
    //This is for the shop to be able to see how much score the player has without directly accessing the variable
    public int GetPlayerScoreValue()
    {
        return _playerScore;
    }

    //Since we update the text a lot, we created a separate method we can call from multiple places
    private void UpdateText()
    {
        scoreText.text = "Player Score = " + _playerScore;
        multiplierText.text = "Player Multiplier = " + _scoreMultiplier;
    }

    //Methos to start auto clicker
    public void StartAutoClicker()
    {
        if(!_isAutoClickerActive)
        {
            _isAutoClickerActive = true;
            StartCoroutine(AutoClickerCoroutine());
        }
    }

    //Method to stop the auto-clicker
    public void StopAutoClicker()
    {
        if(_isAutoClickerActive)
        {
            _isAutoClickerActive = false;
            StopCoroutine(AutoClickerCoroutine());
        }
    }

    //Coroutine for the auto-clicker
    private IEnumerator AutoClickerCoroutine()
    {
        while (_isAutoClickerActive)
        {
            AddScore(_autoClickAmount);
            yield return new WaitForSeconds(_autoClickInterval);
        }
    }

    //Overloaded AddScore method to allow adding a specific amount
    private void AddScore(int amount)
    {
        _playerScore += amount * _scoreMultiplier;
        UpdateText();
    }

}
