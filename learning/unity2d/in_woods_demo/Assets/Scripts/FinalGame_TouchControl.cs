using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalGame_TouchControl : MonoBehaviour
{
    private FinalGame_Woodcutter _woodcutter;
    RectTransform btnRect;
    private void Start()
    {
        _woodcutter = FindObjectOfType<FinalGame_Woodcutter>();
        btnRect = GetComponent<RectTransform>();
    }
    public void GoRightPush()
    {
        _woodcutter.touchR = true;
    }
    public void GoRightPop()
    {
        _woodcutter.touchR = false;
    }
    public void GoLeftPush()
    {
        _woodcutter.touchL = true;
    }

    public void GoLeftPop()
    {
        _woodcutter.touchL = false;

    }

    public void JumpPush()
    {
        _woodcutter.touchJ = true;
        btnRect.anchoredPosition = new Vector2(btnRect.anchoredPosition.x+200, btnRect.anchoredPosition.y);
        StartCoroutine("delayJump");

        //gameObject.SetActive(false);
        //btnRect.localScale=Vector3.zero;
        //StartCoroutine("Delay");

    }
    private IEnumerator delayJump()
    {
        yield return new WaitForSecondsRealtime(Time.deltaTime);
        _woodcutter.touchJ = false;

        yield return new WaitForSecondsRealtime(1.5f);
        btnRect.anchoredPosition = new Vector2(btnRect.anchoredPosition.x - 200, btnRect.anchoredPosition.y);
    }

    public void ToDoPush()
    {
        _woodcutter.touchDo = true;
        StartCoroutine("delayToDo");

        //btnRect.localScale = Vector3.zero;
        //StartCoroutine(nameof(Delay));

    }
    private IEnumerator delayToDo()
    {
        yield return new WaitForSecondsRealtime(Time.deltaTime);
        _woodcutter.touchDo = false;
        //gameObject.SetActive(false);
    }

    public void BackMenu()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(nameof(DelayMenu));
    }
    IEnumerator DelayMenu()
    {

        yield return new WaitForSecondsRealtime(0.25f);
        SceneManager.LoadScene("FinalGame_Menu");

    }


}
