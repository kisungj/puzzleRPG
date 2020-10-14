using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmOn : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgm;

    void Start()
    {
        //다음 Scene으로 넘어가도 오브젝트가 사라지지않음
        //DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void Audio()
    {
        //오디오에 bgm이라는 파일 연결
        audioSource.clip = bgm;
        //실행시 바로 사운드 재생할건지
        audioSource.playOnAwake = false;
        //오디오 음소거
        audioSource.mute = false;
        //오디오 볼륨
        audioSource.volume = 1.0f;
        //오디오 반복 재생
        audioSource.loop = false;
        //오디오 실행
        audioSource.Play();
        //오디오 멈추기
        //audioSource.Stop();
        //오디오 한번만 실행
        //audioSource.PlayOneShot(bgm);
    }
}
