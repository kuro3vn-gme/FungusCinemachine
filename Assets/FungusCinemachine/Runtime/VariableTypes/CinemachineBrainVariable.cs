using UnityEngine;
using Cinemachine;
using Fungus;

namespace FungusExtensions.Cinemachine
{
	[VariableInfo("Cinemachine", nameof(CinemachineBrain))]
	[AddComponentMenu("")]
	[System.Serializable]
	public class CinemachineBrainVariable : VariableBase<CinemachineBrain> { }

	[System.Serializable]
	public struct CinemachineBrainData
	{
		[SerializeField]
		[VariableProperty("<Value>", typeof(CinemachineBrainVariable))]
		public CinemachineBrainVariable cinemachineBrainRef;

		[SerializeField]
		public CinemachineBrain cinemachineBrainVal;

		public static implicit operator CinemachineBrain(CinemachineBrainData cinemachineBrainData)
		{
			return cinemachineBrainData.Value;
		}

		public CinemachineBrainData(CinemachineBrain v)
		{
			cinemachineBrainVal = v;
			cinemachineBrainRef = null;
		}

		public CinemachineBrain Value
		{
			get { return (cinemachineBrainRef == null) ? cinemachineBrainVal : cinemachineBrainRef.Value; }
			set { if (cinemachineBrainRef == null) { cinemachineBrainVal = value; } else { cinemachineBrainRef.Value = value; } }
		}

		public string GetDescription()
		{
			if (cinemachineBrainRef == null)
			{
				return cinemachineBrainVal != null ? cinemachineBrainVal.ToString() : "Null";
			}
			else
			{
				return cinemachineBrainRef.Key;
			}
		}
	}
}