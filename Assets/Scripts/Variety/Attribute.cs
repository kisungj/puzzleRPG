using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attribute : MonoBehaviour
{
    //하이라키에 있는 오브젝트
    public Image attImg;
    //바꾸고 싶은 이미지 배열
    public Sprite[] changeSprite;
    //현재 이미지
    public int currentimg;

    void Awake()
    {
        //실행시 true 시켜서 보여줘야함
        attImg.enabled = true;

        //딱 한번 랜덤하게 지정해주기 위해
        currentimg = Random.Range(0, 5);
        attImg.sprite = changeSprite[currentimg];
    }
}
