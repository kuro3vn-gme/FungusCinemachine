using System.Collections;
using UnityEngine;
using Cinemachine;
using Fungus;

namespace FungusExtensions.Cinemachine
{
    [CommandInfo("Cinemachine",
                 "Set VirtualCamera Priority",
                 "Set VirtualCamera's priority.")]
    [AddComponentMenu("")]
    public class SetVirtualCameraPriority : Command
    {
        [Tooltip("Cinemachine Virtual Camera")]
        [SerializeField] protected CinemachineVirtualCameraData virtualCamera = new CinemachineVirtualCameraData();

        [Tooltip("Priority")]
        [SerializeField] protected IntegerData priority = new IntegerData();

        #region Public members

        public override void OnEnter()
        {
            if (virtualCamera.Value == null)
            {
                Continue();
                return;
            }
            virtualCamera.Value.Priority = priority.Value;
            Continue();
        }

        public override string GetSummary()
        {
            if (virtualCamera.Value == null)
            {
                return "Error: No VirtualCamera selected";
            }
            return $"{virtualCamera.Value.name} , {priority.Value}";
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        public override bool HasReference(Variable variable)
        {
            return base.HasReference(variable) ||
                (virtualCamera.cinemachineVirtualCameraRef == variable) ||
                (priority.integerRef == variable);
        }

        #endregion
    }
}