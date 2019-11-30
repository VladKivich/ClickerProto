﻿using Helpers;

namespace Assets.Scripts.Helpers.GameEvents
{
    public abstract class BaseGEvent { }

    public class AddMoneyGEvent : BaseGEvent
    {
        public readonly int money;
        public AddMoneyGEvent(int money)
        {
            this.money = money;
        }
    }

    public class ModuleUpgradeGEvent : BaseGEvent
    {
        public readonly int moduleGrade;

        public readonly int computerModule;
        public ModuleUpgradeGEvent(ComputerModule module, int grade)
        {
            computerModule = (int)module;
            moduleGrade = grade;
        }
    }
}
