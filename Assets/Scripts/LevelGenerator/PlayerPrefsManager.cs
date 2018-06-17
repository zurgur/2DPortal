using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string SHOTGUN_KEY = "shotgun_unlocked";
    const string MAGNET_KEY = "magnet_unlocked";
    const string SHIELD_KEY = "shield_unlocked";
    const string HEALTH_UPP_KEY = "health_up_unlocked";
    const string MONEY_KEY = "money_amount";
    const string DISTANC_KEY = "distance_key";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static int GetMoney()
    {
        return PlayerPrefs.GetInt(MONEY_KEY);
    }

    public static void AddMoney(int amount)
    {
        int current = GetMoney();
        current += amount;
        PlayerPrefs.SetInt(MONEY_KEY, current);
    }


    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query level not in build order");
            return false;
        }
    }


    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
    public static bool IsItemnlocked(int item)
    {
        int itemValue = 0;

        switch (item+1)
        {
            case 1:
                itemValue = PlayerPrefs.GetInt(SHOTGUN_KEY);
                break;
            case 2:
                itemValue = PlayerPrefs.GetInt(MAGNET_KEY);
                break;
            case 3:
                itemValue = PlayerPrefs.GetInt(HEALTH_UPP_KEY);
                break;
            case 4:
                itemValue = PlayerPrefs.GetInt(SHIELD_KEY);
                break;
            default:
                itemValue = 0;
                break;
        }
        return itemValue == 1;
    }
    public static void UnlockItem(int item)
    {

        switch (item + 1)
        {
            case 1:
                PlayerPrefs.SetInt(SHOTGUN_KEY, 1);
                break;
            case 2:
                PlayerPrefs.SetInt(MAGNET_KEY, 1);
                break;
            case 3:
                PlayerPrefs.SetInt(HEALTH_UPP_KEY, 1);
                break;
            case 4:
                PlayerPrefs.SetInt(SHIELD_KEY, 1);
                break;
            default:
                break;
        }
    }
    public static float getDistance()
    {
        return PlayerPrefs.GetFloat(DISTANC_KEY);
    }
    public static void setDistance(float newDistance)
    {
        float current = PlayerPrefs.GetFloat(DISTANC_KEY);
        if(current < newDistance)
        {
            PlayerPrefs.SetFloat(DISTANC_KEY, newDistance);
        }
    }
}