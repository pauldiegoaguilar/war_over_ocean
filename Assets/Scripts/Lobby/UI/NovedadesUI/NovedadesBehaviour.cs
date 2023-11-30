using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovedadesBehaviour : MonoBehaviour
{
    [SerializeField] private Button atrasBtn;

    private void Awake()
    {

        atrasBtn.onClick.AddListener(() =>
        {
            GeneralBack.Instance.Hide();
            NovedadesUI.Instance.Hide();
        });
    }
}
