using System;
using System.Linq;
using UnityEngine;
using BeatThis.Game.ControlActions;
using BeatThis.Game.AnimationEvents;
using System.Collections;

namespace BeatThis.Game.Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class MainCharacterController : MonoBehaviour, IControllerable, IAnimated
    {
        private CharacterController controller;

        [SerializeField] public float MoveSpeed;
        [SerializeField] private Vector3 moveDirection;
        private float baseMoveSpeed;
        private float speedCompensation;

        private readonly int[] Lanes = {-1, 0, 1};
        public int CurrentLane { get; private set; } = 0;

        [SerializeField] private Transform transformer;
        [SerializeField] private Animator animator;
        [SerializeField] float BaseColliderY;
        [SerializeField] float AnimationSpeedMiltiplier;

        private ProcessableActionRegistry actionRegistry;

        public void Init()
        {
            controller = GetComponent<CharacterController>();
            animator.SetFloat("Velocity", AnimationSpeedMiltiplier * MoveSpeed);
            baseMoveSpeed = Settings.GetInstance().GetFloat("defaultUnitsPerSecond");
        }

        public void MoveForFixedUpdate()
        {
            float calculatedMoveSpeed = (baseMoveSpeed + speedCompensation) * MoveSpeed * Time.fixedDeltaTime;
            controller.Move(moveDirection * calculatedMoveSpeed);
        }

        public void SetActionRegistry(ProcessableActionRegistry actionRegistry)
        {
            this.actionRegistry = actionRegistry;
        }

        public void Attack()
        {
            animator.SetTrigger("Attack");
        }

        public void Down()
        {
            throw new NotImplementedException();
        }

        public void Left()
        {
            int newLine = CurrentLane - 1;
            if (Lanes.Contains(newLine))
            {
                CurrentLane = newLine;
                animator.SetTrigger("SlideLeft");
            }
        }

        public void Right()
        {
            int newLine = CurrentLane + 1;
            if (Lanes.Contains(newLine))
            {
                CurrentLane = newLine;
                animator.SetTrigger("SlideRight");
            }
        }

        public void Up()
        {
            animator.SetTrigger("Jump");
        }

        public void OnAnimationStart(Type ActionType)
        {
            if (ActionType == typeof(LeftAction) || ActionType == typeof(RightAction))
            {
                speedCompensation = -Settings.GetInstance().GetFloat("sideUnitsPerSecond");
            }    
            actionRegistry.GetAction(ActionType).StartProcessing();
        }

        public void OnAnimationEnd(Type ActionType)
        {
            if (ActionType == typeof(LeftAction) || ActionType == typeof(RightAction))
            {
                speedCompensation = 0.0f;
            }
            actionRegistry.GetAction(ActionType).FinishProcessing();
        }

        public IEnumerator CalculateSpeed()
        {
            float startPosition = transform.position.z;
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Per one second: " + (transform.position.z - startPosition).ToString());
        }

        public IEnumerator CalculateMoveSideDistance()
        {
            float startPosition = transform.position.x;
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Move side: " + (transform.position.x - startPosition).ToString());
        }
    }
}
