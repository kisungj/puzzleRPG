using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Slider loadingBar;
    public Text loadingText;

    void Start()
    {
        StartCoroutine(NextScene(1));
    }

    IEnumerator NextScene(int num)
    {
        //해당 씬을 비동기 형식으로 로드한다.
        AsyncOperation async = SceneManager.LoadSceneAsync(num);

        //해당 동작이 준비되었는지 여부.
        while(!async.isDone)
        {
            //async.progress 얘가 그냥 씬의 메모리 상태를 반환해준다.
            loadingBar.value = async.progress;
            loadingText.text = (async.progress * 100.0f).ToString() + "%";

            yield return null;
        }

    }
}
