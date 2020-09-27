using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //현재 게임 상태
    public enum GameState
    {
        Start,
        Pause
    }

    public GameState gameState;

    public GameObject gameOption;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //설정 창 열기
    public void OpenOptionWindow()
    {
        gameOption.SetActive(true);
        //게임 속도0으로 바꿔서 멈춤
        Time.timeScale = 0;
        gameState = GameState.Pause;
    }

    //설정 창 닫기
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        //게임 이어서하기
        Time.timeScale = 1.0f;
        gameState = GameState.Start;
    }

    //main 씬으로 넘어가기
    public void PreviousScene()
    {
        SceneManager.LoadScene(1);
    }

    //마우스 버튼위에 올라가면
    void MouseOver(bool isOver)
    {

    }
}
