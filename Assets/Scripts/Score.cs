using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextField;

    private static Action<int> ScoreAction;

    private static int _value = 0;
    public static int Value {
        get => _value;
        set
        {
            if(ScoreAction != null) ScoreAction(value);
            _value = value;
        }
    }

    private void OnEnable()
    {
        ScoreAction += SetScoreText;
        Drops.Defeated += DefeatedBehavior;
    }

    private void OnDisable()
    {
        ScoreAction -= SetScoreText;
        Drops.Defeated -= DefeatedBehavior;
    }

    private void SetScoreText(int v)
    {
        TextField.text = v.ToString();
    }

    private void DefeatedBehavior(Drops drops)
    {
        drops.Pause(true);
        StartCoroutine(EndGameCallMainMenu(drops));
    }

    private IEnumerator EndGameCallMainMenu(Drops drops)
    {
        TextField.text = $"VOCÊ FEZ {Value} PONTOS!!";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        
        Value = 0;
        drops.Pause(false);
    }
}