using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    public int playerStatPool = 25;
    public int npcStatPool = 25;


    public int playerStrengthStat;
    public int playerAgilityStat;
    public int playerIntelligenceStat;

    public int npcStrengthStat;
    public int npcAgilityStat;
    public int npcIntelligenceStat;


    public int playerRhythmStat;
    public int playerStyleStat;
    public int playerLuckStat;

    public int npcRhythmStat;
    public int npcStyleStat;
    public int npcLuckStat;


    public float strengthToRythm = 2.3f;
    public float agilityToStyle = 0.7f;
    public float intelligenceToLuck = 2.1f;

    public float chanceOfWinning = 0.7f;

    public int level = 5;
    public int experiencePoints = 25;
    public int expPointsThreshold = 75;

    // Start is called before the first frame update
    void Start()
    {
        SetUpReferences();
        GeneratePhysicalStats();
        CalculateDancingStats();

    }

    public void SetUpReferences()
    {

    }

    public void GeneratePhysicalStats()
    {

        int currentValue = Random.Range(0, playerStatPool);
        int npcCurrentValue = Random.Range(0, npcStatPool);




        playerStrengthStat = playerStrengthStat + currentValue;
        playerStatPool = playerStatPool - currentValue;
        Debug.Log("Player Strength = " + playerStrengthStat);

        npcStrengthStat = npcStrengthStat + npcCurrentValue;
        npcStatPool = npcStatPool - npcCurrentValue;
        Debug.Log("NPC Strength = " + npcStrengthStat);

        


        currentValue = Random.Range(0, playerStatPool);
        playerAgilityStat = playerAgilityStat + currentValue;
        playerStatPool = playerStatPool - currentValue;
        Debug.Log("Player Agility = " + playerAgilityStat);

        npcCurrentValue = Random.Range(0, npcStatPool);
        npcAgilityStat = npcAgilityStat + npcCurrentValue;
        npcStatPool = npcStatPool - npcCurrentValue;
        Debug.Log("NPC Agility = " + npcAgilityStat);




        playerIntelligenceStat = playerIntelligenceStat + playerStatPool;
        playerStatPool = 0;
        Debug.Log("Player Intelligence = " + playerIntelligenceStat);

        npcIntelligenceStat = npcIntelligenceStat + npcStatPool;
        npcStatPool = 0;
        Debug.Log("NPC Intelligence = " + npcIntelligenceStat);

    }

    public void CalculateDancingStats()
    {

        playerRhythmStat = (int)(playerStrengthStat * strengthToRythm);
        Debug.Log("Rhythm Level = " + playerRhythmStat);

        npcRhythmStat = (int)(npcStrengthStat * strengthToRythm);
        Debug.Log("Rhythm Level = " + npcRhythmStat);




        playerStyleStat = (int)(playerAgilityStat * agilityToStyle);
        Debug.Log("Style Level = " + playerStyleStat);

        npcStyleStat = (int)(npcAgilityStat * agilityToStyle);
        Debug.Log("Style Level = " + npcStyleStat);




        playerLuckStat = (int)(playerIntelligenceStat * intelligenceToLuck);
        Debug.Log("Luck Level =  " + playerLuckStat);

        npcLuckStat = (int)(npcIntelligenceStat * intelligenceToLuck);
        Debug.Log("NPC Luck Level =  " + npcLuckStat);

    }
}