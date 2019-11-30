﻿using Assets.Scripts.Helpers;
using Controllers;
using Models;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BaseScripts
{
    public class Core : MonoBehaviour
    {
        #region Buttons&UI

        [SerializeField] private ClickerMainButton mainButton;
        [SerializeField] private InGameUI inGameUI;

        #endregion

        #region Controllers&Models

        private ClickerController clickerController;
        private UIController uiController;
        private QuestController questController;

        private Dictionary<Type, BaseController> controllers;

        #endregion

        [SerializeField] private Camera mainCamera;

        public static Core Instance { get; private set; }
        public MonoBehaviour GetMB { get; private set; }
        public GameProgress GetProgress
        {
            get
            {
                return gameProgress;
            }
        }

        private GameProgress gameProgress;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            if (GetMB == null)
            {
                GetMB = this;
            }

            if (gameProgress == null)
            {
                gameProgress = new GameProgress();
            }
        }

        private void Start()
        {
            #region CreateControllers

            controllers = new Dictionary<Type, BaseController>();

            clickerController = new ClickerController(mainButton);
            uiController = new UIController(inGameUI, clickerController);
            questController = new QuestController();

            #endregion
        }

        public void AddController<C>(C controller) where C : BaseController
        {
            var type = typeof(C);
            if (!controllers.ContainsKey(type))
            {
                controllers.Add(type, controller);
            }
        }

        public C GetController<C>() where C : BaseController
        {
            var type = typeof(C);
            if (controllers.ContainsKey(type))
            {
                return (C)controllers[type];
            }
            return null;
        }

        public List<IGameEventSender> GetQuestsEventsSenders()
        {
            var result = new List<IGameEventSender>();
            foreach (var item in controllers.Values)
            {
                if (item is IGameEventSender requredType)
                {
                    result.Add(requredType);
                }
            }
            return result;
        }
    }
}

