using BeatThis.Game.ControlActions;
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
        

        public void Start()
        { 
            if (Settings.GetInstance().IsEmpty())
            {
                InitializeSettings();
            }
            mainCharacterController = mainCharacter.GetComponent<MainCharacterController>();
            mainCharacterController.Init();
            InitializeActionRegistry();
            mainCharacterController.SetActionRegistry(actionRegistry);
            actionChecker = new ActionChecker(actionRegistry, actionDetector);
            mapGenerator.SetActionChecker(actionChecker);
            mapGenerator.startTimeOffset = startTimeOffset;
            mapGenerator.Generate(mainCharacterController.MoveSpeed, mainCharacter.transform.position.z);
        }

        private void InitializeActionRegistry()
        {
            actionRegistry = new ProcessableActionRegistry();
            actionRegistry.AddAction(new UpAction(mainCharacterController));
            actionRegistry.AddAction(new LeftAction(mainCharacterController));
            actionRegistry.AddAction(new RightAction(mainCharacterController));
            actionRegistry.AddAction(new SingleTapAction(mainCharacterController));
        }

        private void InitializeSettings()
        {
            Settings settings = Settings.GetInstance();
            settings.Set("defaultUnitsPerSecond", "2.435762");
            settings.Set("sideUnitsPerSecond", "1.33");
            settings.Set("laneDistance", "1.4");
            //settings.Set("mapSeed", "1655138556");
            settings.Set("mapSeed", "1655600239");
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