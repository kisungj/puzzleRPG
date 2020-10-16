using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    //데이터 저장
    [SerializeField]
    private DataSave dataSave;

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
        GameObject btnName = EventSystem.current.currentSelectedGameObject;
        if(btnName.name == "Stage1Clear_Button")
        {
            dataSave.Save(1);
            SceneManager.LoadScene(1);
        }
        else if(btnName.name == "Stage2Clear_Button")
        {
            dataSave.Save(2);
            SceneManager.LoadScene(1);
        }
        else if(btnName.name == "Stage3Clear_Button")
        {
            dataSave.Save(3);
            SceneManager.LoadScene(1);
        }
    }

    //스테이지 다시하기
    public void StageReStart()
    {
        GameObject btnName = EventSystem.current.currentSelectedGameObject;

        if (btnName.name == "Stage1ReStart_Button")
        {
            SceneManager.LoadScene(2);
        }
        else if (btnName.name == "Stage2ReStart_Button")
        {
            SceneManager.LoadScene(3);
        }
        else if (btnName.name == "Stage3ReStart_Button")
        {
            SceneManager.LoadScene(4);
        }
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
