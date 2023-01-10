using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Text _collectedMoneyText;
    [SerializeField] private Text _maxMoneyText;

    private void OnEnable()
    {
        _unit.MaxMoneyValueChanged += OnMaxMoneyValueChanged;
        _unit.CollectedMoneyValueChanged += OnCollectedMoneyValueValueChanged;
    }

    private void OnDisable()
    {
        _unit.MaxMoneyValueChanged -= OnMaxMoneyValueChanged;
        _unit.CollectedMoneyValueChanged -= OnCollectedMoneyValueValueChanged;
    }

    private void OnCollectedMoneyValueValueChanged(object value)
    {
        _collectedMoneyText.text = value.ToString();
    }

    private void OnMaxMoneyValueChanged(object value)
    {
        _maxMoneyText.text = value.ToString();
    }
}
