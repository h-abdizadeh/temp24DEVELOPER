using System.IO;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    string highScoreFilePath;
    PlayerCamera playerCamera;
    int highScore = 0;
    public bool endOfStage;
    // Start is called before the first frame update
    void Start()
    {
        highScoreFilePath = $"{Application.persistentDataPath}\\highScoreFile.txt";
        playerCamera = FindFirstObjectByType<PlayerCamera>();

        if (File.Exists(highScoreFilePath))
        {
            int.TryParse(File.ReadAllText(highScoreFilePath), out highScore);
        }
        else
        {
            File.WriteAllText(highScoreFilePath, "0");
        }
        transform.GetComponent<TMP_Text>().text = highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        var userScore = playerCamera.score;

        if (userScore > highScore && endOfStage)
        {
            highScore = userScore;

            File.WriteAllText(highScoreFilePath, userScore.ToString());
            transform.GetComponent<TMP_Text>().text = highScore.ToString();
            endOfStage = false;
        }



    }
}
