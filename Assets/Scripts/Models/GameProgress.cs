﻿using System;

namespace Models
{
    public interface IModel
    {
        event Action OnModelUpdate;
    }
    public interface IComputerComponents
    {
        float CPUCoolDownPercentagePerStep { get; }
        float CPUHeatPercentagePerClick { get; }
        int GPUAutoClickRewardPerSecond { get; }
        int MoneyForSingleClick { get; }
        float GPUFillBarPercentagePerClick { get; }
    }

    public class GameProgress : IComputerComponents, IModel
    {
        public int currentAmount { get; private set; }
        public event Action OnModelUpdate;

        //TODO: Система улучшений
        public float CPUCoolDownPercentagePerStep { get; private set; } = 5f;
        public float CPUHeatPercentagePerClick { get; private set; } = 7.5f;
        public int GPUAutoClickRewardPerSecond { get; private set; } = 50;
        public float GPUFillBarPercentagePerClick { get; private set; } = 2.75f;
        public int MoneyForSingleClick { get; private set; } = 10;

        public GameProgress()
        {
            currentAmount = 0;
        }

        public void AddMoneyForClick()
        {
            currentAmount += MoneyForSingleClick;
            OnModelUpdate?.Invoke();
        }

        public void AddMoneyForAutoClick(int money)
        {
            currentAmount += money;
            OnModelUpdate?.Invoke();
        }

        public void AddMoney(int amount)
        {
            currentAmount += amount;
            OnModelUpdate?.Invoke();
        }

        public bool CanSpendMoney(int amountToSpend)
        {
            if (currentAmount >= amountToSpend)
            {
                currentAmount -= amountToSpend;
                return true;
            }
            return false;
        }
    }
}

