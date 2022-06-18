using BeatThis.Game;
using NUnit.Framework;
using UnityEngine;
using BeatThis.Game.ControlActions;
using BeatThis.Game.Controllers;
using BeatThis.Game.Obstacles;
using System;

public class GameTests
{
    class MainCharacterControllerMock : IControllerable
    {
        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Down()
        {
            throw new System.NotImplementedException();
        }

        public void Left()
        {
            throw new System.NotImplementedException();
        }

        public void Right()
        {
            throw new System.NotImplementedException();
        }

        public void Up()
        {
            throw new System.NotImplementedException();
        }
    }

    class ObstacleWithDownActionMock : IObstacle
    {
        public int[] AvailableLanes { get; } = { 0 };

        public Type[] ApplicableActions { get; } = { typeof(DownAction) };

        public int LaneWidth { get;  } = 1;

        public bool StrictLaneCheck { get; } = false;
        public bool isPassed = false;

        public bool IsPassed()
        {
            return isPassed;
        }

        public void Pass()
        {
            isPassed = true;
        }
    }

    class ObstacleWithUpActionMock : IObstacle
    {
        public int[] AvailableLanes { get; } = { 0 };

        public Type[] ApplicableActions { get; } = { typeof(UpAction) };

        public int LaneWidth { get; } = 1;

        public bool StrictLaneCheck { get; } = false;
        public bool isPassed = false;

        public bool IsPassed()
        {
            return isPassed;
        }

        public void Pass()
        {
            isPassed = true;
        }
    }

    class ActionDetectorMock_LastActionIsUpAction : ActionDetector
    {
        public void SetLastAction_UpAction()
        {
            LastAction = typeof(UpAction);
        }
    }

    private ProcessableActionRegistry actionRegistry;
    private MainCharacterControllerMock controllerMock;
    private ObstacleWithDownActionMock obstacleWithDownActionMock;
    private ObstacleWithUpActionMock obstacleWithUpActionMock;
    private ActionChecker actionChecker;
    private ActionDetectorMock_LastActionIsUpAction actionDetectorMock;

    [SetUp]
    public void Setup()
    {
        actionRegistry = new ProcessableActionRegistry();
        controllerMock = new MainCharacterControllerMock();
        obstacleWithDownActionMock = new ObstacleWithDownActionMock();
        obstacleWithUpActionMock = new ObstacleWithUpActionMock();
        actionDetectorMock = new GameObject().AddComponent<ActionDetectorMock_LastActionIsUpAction>().GetComponent<ActionDetectorMock_LastActionIsUpAction>();

        actionDetectorMock.SetLastAction_UpAction();

        actionRegistry.AddAction(new UpAction(controllerMock));
        actionRegistry.GetAction(typeof(UpAction)).StartProcessing();

        actionChecker = new ActionChecker(actionRegistry, actionDetectorMock);
    }

    [Test]
    public void UpAction_DoesNotFitInTime_For_ObstacleWithDownAction()
    {
        Assert.IsFalse(actionChecker.IsApplicableActionInTime(obstacleWithDownActionMock, Time.timeSinceLevelLoad));
    }

    [Test]
    public void UpAction_FitsInTime_For_ObstacleWithUpAction()
    {
        Assert.IsTrue(actionChecker.IsApplicableActionInTime(obstacleWithUpActionMock, Time.timeSinceLevelLoad));
    }

    [TearDown]
    public void Teardown()
    {
        UnityEngine.Object.Destroy(actionDetectorMock.gameObject);
    }
}
