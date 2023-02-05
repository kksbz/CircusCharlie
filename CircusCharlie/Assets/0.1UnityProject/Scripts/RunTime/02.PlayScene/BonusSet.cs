using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSet : MonoBehaviour
{
    private AudioSource bonusAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        bonusAudio = gameObject.GetComponent<AudioSource>();
        bonusAudio.clip = Resources.Load("Audios/BounsGet")as AudioClip;
        // Debug.Log($"보너스오디오 값: {bonusAudio}, 클립:{bonusAudio.clip}");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            StartCoroutine(GetBonus());
        }
    }

    IEnumerator GetBonus()
    {
        bonusAudio.Play();
        yield return new WaitForSeconds(bonusAudio.clip.length * 0.5f);
        bonusAudio.Stop();
        gameObject.SetActive(false);
    }
}
