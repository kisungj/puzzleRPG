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
        Pause,
        ReStart
    }

    //게임 시작시 3초뒤에 나타나게 하려는 UI들
    public GameObject enemyObj;
    public GameObject enemyUI;
    public GameObject attribute;
    public GameObject effectCanvas;
    public GameObject uiCanvas;
    public GameObject platyerma;

    public GameState gameState;
    public GameObject gameOption;

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
        gameState = GameState.ReStart;
    }

    //main 씬으로 넘어가기
    public void PreviousScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    //스테이지 클리어 후 main 씬으로 넘어가기
    public void StageClear()
    {
        SceneManager.LoadScene(1);
    }

    //게임 시작하려면 시간 다시 가동
    public void GameStart()
    {
        uiCanvas.SetActive(true);
        enemyObj.SetActive(true);
        enemyUI.SetActive(true);
        attribute.SetActive(true);
        effectCanvas.SetActive(true);
        platyerma.SetActive(true);
        gameState = GameState.Start;
    }
}
