using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColonyUI : MonoBehaviour
{
    [SerializeField] private Colony _colony;
    [SerializeField] private Text _maxMoneyText;
    [SerializeField] private Text _currentMoneyText;

    private void OnEnable()
    {
        _colony.CurrentMoneyValueChanged += OnCurrentMoneyValueChanged;
        _colony.MaxMoneyValueChanged += OnMaxMoneyValueChanged;
    }

    private void OnDisable()
    {
        _colony.CurrentMoneyValueChanged -= OnCurrentMoneyValueChanged;
        _colony.MaxMoneyValueChanged -= OnMaxMoneyValueChanged;
    }

    private void OnMaxMoneyValueChanged(object value)
    {
        _maxMoneyText.text = value.ToString();
    }

    private void OnCurrentMoneyValueChanged(object value)
    {
        _currentMoneyText.text = value.ToString();
    }
}