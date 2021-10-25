using System.Collections;
using UnityEngine;
using Cinemachine;
using Fungus;

namespace FungusExtensions.Cinemachine
{
    [CommandInfo("Cinemachine",
                 "Set Cinemachine Blend",
                 "Set CinemachineBrain's blend settings.")]
    [AddComponentMenu("")]
    public class SetCinemachineBlend : Command
    {
        [Tooltip("Cinemachine Brain")]
        [SerializeField] protected CinemachineBrainData cinemachineBrain = new CinemachineBrainData();

        [Tooltip("Blend Style")]
        [SerializeField] protected CinemachineBlendDefinition.Style style;

        [Tooltip("Animation Curve")]
        [SerializeField] protected AnimationCurve animationCurve;

        [Tooltip("Time")]
        [SerializeField] protected FloatData time = new FloatData();

        #region Public members

        public override void OnEnter()
        {
            if (cinemachineBrain.Value == null)
			{
                Continue();
                return;
			}
            cinemachineBrain.Value.m_DefaultBlend.m_Style = style;
            cinemachineBrain.Value.m_DefaultBlend.m_CustomCurve = animationCurve;
            cinemachineBrain.Value.m_DefaultBlend.m_Time = time.Value;
            Continue();
        }

		public override string GetSummary()
		{
			if (cinemachineBrain.Value == null)
			{
				return "Error: No CinemachineBrain selected";
			}
            return $"{cinemachineBrain.Value.name} , {style} , {time.Value}";
		}

		public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

		public override bool HasReference(Variable variable)
		{
			return base.HasReference(variable) ||
				(cinemachineBrain.cinemachineBrainRef == variable) ||
				(time.floatRef == variable);
		}

		#endregion
	}
}