using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScoreHandler : MonoBehaviour
{
    [SerializeField] HighscoreHandler highscoreHandler;
    [SerializeField] InputField nameInput;
    [SerializeField] private TextMeshProUGUI playerScoreField;
    private int playerScore = 0 ;
    private string playerName = "AAA";
    private MissionController Mission = null;


    void Awake()
    {
        Mission = this.GetComponent<MissionController>();
    }
    void Update()
    {
        playerScore = Mission.GetScore();
        playerScoreField.text = string.Format("{0:#,##0}", playerScore);
    }
    public void SavePoint(){
        playerName = nameInput.text;
        if(playerName == null) playerName = "AAA";
        highscoreHandler.AddHighscoreIfPossible (new HighscoreElement (playerName, playerScore));
    }
}
