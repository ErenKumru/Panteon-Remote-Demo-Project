using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfoManager : MonoBehaviour
{
    private List<Rankable> characterRankings = new List<Rankable>();
    private Rankable playerCharacter;
    private int playerRanking;

    private void Awake()
    {
        FindAllCharacters();
    }

    private void FindAllCharacters()
    {
        Rankable[] rankables = FindObjectsOfType<Rankable>();

        foreach(Rankable rankable in rankables)
        {
            characterRankings.Add(rankable);
        }

        playerCharacter = FindObjectOfType<PlayerController>().GetComponent<Rankable>();
    }

    private void SortAllCharacterRankings()
    {
        characterRankings.Sort();
    }

    private void CalculatePlayerRanking()
    {
        playerRanking = characterRankings.IndexOf(playerCharacter);
    }

    public int GetPlayerRanking()
    {
        SortAllCharacterRankings();
        CalculatePlayerRanking();
        return playerRanking;
    }

    public int GetTotalNumberOfCharacters()
    {
        return characterRankings.Count;
    }
}
