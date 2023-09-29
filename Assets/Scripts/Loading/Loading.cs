using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

    [SerializeField] private Image LoadingBarFill;
    [SerializeField] private GameObject Barco;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync("Lobby"));
    }

    IEnumerator LoadSceneAsync(string lobby)
    {
        yield return new WaitForSeconds(1.5f); //como hay pocas cosas en la escena lobby, carga rapido y no da tiempo de ver bien la pantalla de carga
        float partes = 62.5f;

        AsyncOperation operation = SceneManager.LoadSceneAsync(lobby);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log("Operation Progress: " + operation.progress);
            Debug.Log("Pregress Value: " + progressValue);

            LoadingBarFill.fillAmount = progressValue;
            Barco.transform.position = new Vector2(Barco.transform.position.x + (partes * operation.progress), Barco.transform.position.y);

            yield return null;
        }
    }
}
