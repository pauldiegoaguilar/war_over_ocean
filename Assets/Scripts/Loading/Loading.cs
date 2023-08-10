using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

    [SerializeField] private Image LoadingBarFill;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync("Lobby"));
    }

    IEnumerator LoadSceneAsync(string lobby)
    {
        yield return new WaitForSeconds(1f); //como hay pocas cosas en la escena lobby, carga rapido y no da tiempo de ver bien la pantalla de carga

        AsyncOperation operation = SceneManager.LoadSceneAsync(lobby);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
}
