using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSave : MonoBehaviour
{
    public Image img;

    int current = 0;

    void Start()
    {
        //다음 Scene으로 넘어가도 오브젝트가 사라지지않음
        //DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        //데이터 초기화
        //PlayerPrefs.DeleteAll();
        //데이터 로드시키기
        Load();
    }

    public void Save(int Clear)
    {
        //SetInt 데이터 Complete라는 키로 Clear값을 저장하라는 의미
        PlayerPrefs.SetInt("Complete", Clear);
    }

    public void Load()
    {
        //Haskey == Complete가 존재한다면 true, 존재하지 않으면 false
        if(PlayerPrefs.HasKey("Complete") == true)
        {
            //GetInt 데이터 Complete라는 키로 꺼낼 수 있다.
            //getfloat, getString도 있음
            current = PlayerPrefs.GetInt("Complete");

            //만약 조건이 맞으면 실행
            if(current == 1)
            {
                img.color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
