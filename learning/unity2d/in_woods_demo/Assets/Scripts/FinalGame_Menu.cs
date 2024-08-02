using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGame_Menu : MonoBehaviour
{
    public void MenuStart()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(nameof(Delay));
    }
    public void MenuExit()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(nameof(ExitDelay));
    }
    public void MenuGithub()
    {
        Application.OpenURL("https://github.com/h-abdizadeh/temp24DEVELOPER/tree/main/learning/unity2d/in_woods_demo");
    }
    public void MenuAssetsSource()
    {
        Application.OpenURL("https://craftpix.net/freebies/free-swamp-game-tileset-pixel-art");
    }


    IEnumerator Delay()
    {

        yield return new WaitForSecondsRealtime(0.15f);
        SceneManager.LoadScene("FinalGame_demo");

    }
    IEnumerator ExitDelay()
    {

        yield return new WaitForSecondsRealtime(0.25f);
        Application.Quit();

    }
}
