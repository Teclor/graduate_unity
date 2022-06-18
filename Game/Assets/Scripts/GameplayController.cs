﻿using BeatThis.Game.ControlActions;
using BeatThis.Game.Generators;
using BeatThis.Game.Controllers;
using UnityEngine;


namespace BeatThis.Game
{
    [RequireComponent(typeof(MapGenerator))]
    [RequireComponent(typeof(ActionDetector))]
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private MapGenerator mapGenerator;
        [SerializeField] private GameObject mainCharacter;
        [SerializeField] private ActionDetector actionDetector;
        [SerializeField] private SceneChanger sceneChanger;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float startTimeOffset;
        private MainCharacterController mainCharacterController;
        private ActionChecker actionChecker;
        private ProcessableActionRegistry actionRegistry;
        

        void Start()
        { 
            if (Settings.GetInstance().IsEmpty())
            {
                initializeSettings();
            }
            mainCharacterController = mainCharacter.GetComponent<MainCharacterController>();
            mainCharacterController.Init();
            initializeActionRegistry();
            mainCharacterController.SetActionRegistry(actionRegistry);
            actionChecker = new ActionChecker(actionRegistry, actionDetector);
            mapGenerator.SetActionChecker(actionChecker);
            mapGenerator.startTimeOffset = startTimeOffset;
            mapGenerator.Generate(mainCharacterController.MoveSpeed, mainCharacter.transform.position.z);
        }

        private void initializeActionRegistry()
        {
            actionRegistry = new ProcessableActionRegistry();
            actionRegistry.AddAction(new UpAction(mainCharacterController));
            actionRegistry.AddAction(new LeftAction(mainCharacterController));
            actionRegistry.AddAction(new RightAction(mainCharacterController));
            actionRegistry.AddAction(new SingleTapAction(mainCharacterController));
        }

        private void initializeSettings()
        {
            Settings settings = Settings.GetInstance();
            settings.Set("mapPartLength", "65.22776");
            settings.Set("defaultUnitsPerSecond", "2.435762"); //rena speed
            settings.Set("sideUnitsPerSecond", "1.2");
            //settings.Set("defaultUnitsPerSecond", "2.945884"); // man_04 speed
            settings.Set("laneDistance", "1.4");
            //settings.Set("mapSeed", "1655138556");
        }

        private void Update()
        {
            if (audioSource.time >= audioSource.clip.length)
            {
                sceneChanger.LoadMenuScene();
            }
            if (actionDetector.CurrentAction != null)
            {
                actionRegistry.GetAction(actionDetector.CurrentAction).CallControllerAction();
            }
            
        }

        private void FixedUpdate()
        {
            mainCharacterController.MoveForFixedUpdate();
        }
    }
}