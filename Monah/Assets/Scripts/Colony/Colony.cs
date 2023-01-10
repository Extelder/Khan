using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{

    public float CurrentMoney
    {
        get{}
        set
        {
            CurrentMoneyValueChanged?.Invoke(value);
        }
    }
        

    [field: SerializeField]
    public float MaxMoney
    {
        get => MaxMoney;
        private set
        {
            this.MaxMoney = value;
            MaxMoneyValueChanged?.Invoke(MaxMoney);
        }
    }

    [field: SerializeField] public float MoneyRate { get; private set; }
    [field: SerializeField] public float EarnMoneyPerRate { get; private set; }

    public bool CanEarnMoney = true;
    [SerializeField] private float currentMoney;

    public event Action<object> CurrentMoneyValueChanged;
    public event Action<object> MaxMoneyValueChanged;

    private void Start()
    {
        StartCoroutine(EarnMoney());
    }

    private IEnumerator EarnMoney()
    {
        while (true)
        {
            yield return new WaitUntil(() => CurrentMoney + MoneyRate < MaxMoney && CanEarnMoney);
            CurrentMoney += EarnMoneyPerRate;
            if (CurrentMoney > MaxMoney)
                CurrentMoney = MaxMoney;
            yield return new WaitForSeconds(MoneyRate);
        }
    }

    private IEnumerator SpendMoney(float spendRate, float spendPerRate)
    {
        while (CurrentMoney > 0)
        {
            CurrentMoney -= spendPerRate;
            yield return new WaitForSeconds(spendRate);
        }
    }
}