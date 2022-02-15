using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class Score_Mananger : Pause_Controler
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _hpText;
    [SerializeField]
    private Text _finalScore;
    [SerializeField]
    private UnityEvent Spawn_Rate;

    private int _score;
    private int _hp;
    private int _doubler;

    private void Start()
    {
        _score = 0;
        _hp = 10;
        _doubler = 1;
        _scoreText.text = ("Ñ÷¸ò: " + _score.ToString());
        _hpText.text = ("HP: " + _hp.ToString());
    }

    private void Update()
    {
        Spawn_Rate_Controler();
        End_Game();
    }

    private void Spawn_Rate_Controler()
    {
        if(_score > 5 * _doubler)
        {
            Spawn_Rate?.Invoke();
            _doubler++;
        }
    }

    public void OnScore(int _killScore)
    {
        _score += _killScore;
        _scoreText.text = ("Ñ÷¸ò: " + _score.ToString());
    }

    public void Receive_Hill_Boost()
    {
        if (_hp > 0)
        {
            _hp++;
            _hpText.text = ("HP: " + _hp.ToString());
        }
    }

    public void Receive_Damage()
    {
        if(_hp > 0)
        {
            _hp--;
            _hpText.text = ("HP: " + _hp.ToString());
        }
    }

    public void End_Game()
    {
        if (_hp <= 0)
        {
            Pause_On();
            _finalScore.text = ("Âàø ñ÷¸ò: " + _score.ToString());
        }
    }
}
