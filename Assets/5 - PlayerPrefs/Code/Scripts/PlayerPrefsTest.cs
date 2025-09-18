using System;
using TMPro;
using UnityEngine;

namespace _5___PlayerPrefs.Code.Scripts
{
    /// <summary>
/// Manages saving, loading, displaying, and deleting player data (name & score)
/// using Unity's PlayerPrefs.
/// </summary>
public class PlayerPrefsTest : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField scoreInputField;
    
    public TMP_Text nameText;
    public TMP_Text scoreText;

    // Keys used to store data in PlayerPrefs
    private const string PlayerNameKey = "PlayerName";
    private const string PlayerScoreKey = "PlayerScore";

    private void Start()
    {
        EnsureDefaultPrefs();
        DisplayPlayerData();
    }

    /// <summary>
    /// Checks if the required PlayerPrefs keys exist.
    /// If they don't, creates them with default values.
    /// </summary>
    private static void EnsureDefaultPrefs()
    {
        if (!PlayerPrefs.HasKey(PlayerNameKey))
        {
            PlayerPrefs.SetString(PlayerNameKey, "-----");
        }

        if (!PlayerPrefs.HasKey(PlayerScoreKey))
        {
            PlayerPrefs.SetString(PlayerScoreKey, "0");
        }

        PlayerPrefs.Save(); // Force save to disk
    }

    /// <summary>
    /// Loads player data from PlayerPrefs and shows it in the UI.
    /// </summary>
    private void DisplayPlayerData()
    {
        // If keys don't exist, show empty text
        nameText.text = PlayerPrefs.HasKey(PlayerNameKey)
            ? PlayerPrefs.GetString(PlayerNameKey)
            : string.Empty;

        scoreText.text = PlayerPrefs.HasKey(PlayerScoreKey)
            ? PlayerPrefs.GetString(PlayerScoreKey)
            : string.Empty;
    }

    /// <summary>
    /// Updates PlayerPrefs with the data entered in the input fields.
    /// </summary>
    public void UpdatePlayerData()
    {
        var nameValue = nameInputField.text;
        var scoreValue = scoreInputField.text;

        PlayerPrefs.SetString(PlayerNameKey, nameValue);
        PlayerPrefs.SetString(PlayerScoreKey, scoreValue);
        PlayerPrefs.Save();

        DisplayPlayerData();
    }

    /// <summary>
    /// Deletes saved player data (name and score) from PlayerPrefs.
    /// </summary>
    public void DeletePlayerData()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            PlayerPrefs.DeleteKey(PlayerNameKey);
        }

        if (PlayerPrefs.HasKey(PlayerScoreKey))
        {
            PlayerPrefs.DeleteKey(PlayerScoreKey);
        }

        PlayerPrefs.Save();
        DisplayPlayerData();
    }
}
}