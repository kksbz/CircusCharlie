using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private AudioSource startAudio = default;
    public AudioClip gameStartAudio= default;

    public void StartBtn()
    {
        startAudio = gameObject.GetComponent<AudioSource>();
        StartCoroutine(StageImageActiveSetup());
    } //StartBtn

    IEnumerator StageImageActiveSetup()
    {
        AudioSource startAudio_2 = gameObject.FindChildObj("StartAudio").gameObject.GetComponent<AudioSource>();
        startAudio.clip = gameStartAudio;
        startAudio.Play();
        startAudio_2.Play();
        yield return new WaitForSeconds(2f);
        GameManager.Instance.ShowStageImage(true);
        yield return new WaitForSeconds(2f);
        GFunc.LoadScene(GData.PLAY_STAGE_1_NAME);
    }
}
