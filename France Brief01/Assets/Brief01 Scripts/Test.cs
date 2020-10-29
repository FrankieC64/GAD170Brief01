using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int playerStatPointsPool = 25;
    public int npcStatPointsPool = 25;

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

    public int playerDancePower;
    public int npcDancePower;

    public float strengthToRythm = 1.9f;
    public float agilityToStyle = 0.9f;
    public float intelligenceToLuck = 1.7f;

    public int playerStartLevel = 5;
    public int playerLevelUp;
    public int levelPoint = 1;
    public int currentExpPoints = 25;
    public int expPointsThreshold = 90;
    public int pointPool = 12;


    // Start is called before the first frame update
    private void Start()
    {
        GeneratePhysicalStats();
        CalculateDancingStats();
        DancePoints();
        ReturnDancePowerLevel(playerDancePower, npcDancePower);
        AddXP();
        LevelUp();
        DistributePhysicalStatsOnLevelUp();

    }

    public void GeneratePhysicalStats()
    {
        int currentValue = Random.Range(0, playerStatPointsPool);

        playerStrengthStat = playerStrengthStat + currentValue;
        playerStatPointsPool = playerStatPointsPool - currentValue;
        Debug.Log("Strength: " + playerStrengthStat);

        currentValue = Random.Range(0, playerStatPointsPool);
        playerAgilityStat = playerAgilityStat + currentValue;
        playerStatPointsPool = playerStatPointsPool - currentValue;
        Debug.Log("Agility: " + playerAgilityStat);

        playerIntelligenceStat = playerIntelligenceStat + playerStatPointsPool;
        playerStatPointsPool = 0;
        Debug.Log("Intelligence: " + playerIntelligenceStat);



        int npcCurrentValue = Random.Range(0, npcStatPointsPool);

        npcStrengthStat = npcStrengthStat + npcCurrentValue;
        npcStatPointsPool = npcStatPointsPool - npcCurrentValue;

        npcCurrentValue = Random.Range(0, npcStatPointsPool);
        npcAgilityStat = npcAgilityStat + npcCurrentValue;
        npcStatPointsPool = npcStatPointsPool - npcCurrentValue;

        npcIntelligenceStat = npcIntelligenceStat + npcStatPointsPool;
        npcStatPointsPool = 0;
    }

    public void CalculateDancingStats()
    {
        playerRhythmStat = (int)(playerStrengthStat * strengthToRythm);
        Debug.Log("Rhythm: " + playerRhythmStat);

        playerStyleStat = (int)(playerAgilityStat * agilityToStyle);
        Debug.Log("Style: " + playerStyleStat);

        playerLuckStat = (int)(playerIntelligenceStat * intelligenceToLuck);
        Debug.Log("Luck:  " + playerLuckStat);



        npcRhythmStat = (int)(npcStrengthStat * strengthToRythm);

        npcStyleStat = (int)(npcAgilityStat * agilityToStyle);

        npcLuckStat = (int)(npcIntelligenceStat * intelligenceToLuck);
    }

    public void SetPercentageValue(float normalisedValue)
    {

    }

    public void DancePoints()
    {
        playerDancePower = (int)(playerDancePower + playerRhythmStat + playerStyleStat + playerLuckStat);
        Debug.Log("Player has " + playerDancePower + " dance points");

        npcDancePower = (int)(npcDancePower + npcRhythmStat + npcStyleStat + npcLuckStat);
    }

    public int ReturnDancePowerLevel(int playerDancePower, int npcDancePower)
    {
        if (playerDancePower > npcDancePower)
        {
            Debug.Log("The winner is: Player. Player had " + playerDancePower + " while NPC had " + npcDancePower + " points.");
        }
        else if (npcDancePower > playerDancePower)
        {
            Debug.Log("The winner is: NPC. NPC had " + npcDancePower + " while Player had " + playerDancePower + " points.");
        }
        else if (npcDancePower == playerDancePower)
        {
            Debug.Log("The battle was a draw");
            return 0;
        }
        return 0;
    }

    public void AddXP()
    {
        int expPoints = Random.Range(50, 75);

        if (playerDancePower > npcDancePower)
        {
            currentExpPoints = currentExpPoints + expPoints;
            Debug.Log("Player gained " + expPoints + " XP.");
        }
    }
    

    private void LevelUp()
    {
        playerLevelUp = (int)(playerStartLevel);

        if (currentExpPoints > 90)
        {
            playerLevelUp = (int)(playerStartLevel + levelPoint);
            Debug.Log("Player leveled up.");
            Debug.Log("Level: " + playerLevelUp);
        }
        else if (currentExpPoints < 90)
        {
            Debug.Log("Level: " + playerLevelUp);
        }
    }

    public void DistributePhysicalStatsOnLevelUp()
    {
        if (playerLevelUp > playerStartLevel)
        {
            int levelPoints = Random.Range(0, pointPool);

            playerStrengthStat = playerStrengthStat + levelPoints;
            pointPool = pointPool - levelPoints;
            Debug.Log("Strength: " + playerStrengthStat);

            levelPoints = Random.Range(0, pointPool);
            playerAgilityStat = playerAgilityStat + levelPoints;
            pointPool = pointPool - levelPoints;
            Debug.Log("Agility: " + playerAgilityStat);


            playerIntelligenceStat = playerIntelligenceStat + pointPool;
            pointPool = 0;
            Debug.Log("Intelligence: " + playerIntelligenceStat);
        }

    }

}
