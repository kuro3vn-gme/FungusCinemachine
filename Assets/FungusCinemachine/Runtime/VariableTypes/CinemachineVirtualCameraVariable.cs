using UnityEngine;
using Cinemachine;
using Fungus;

namespace FungusExtensions.Cinemachine
{
	[VariableInfo("Cinemachine", nameof(CinemachineVirtualCamera))]
	[AddComponentMenu("")]
	[System.Serializable]
	public class CinemachineVirtualCameraVariable : VariableBase<CinemachineVirtualCamera> { }

	[System.Serializable]
	public struct CinemachineVirtualCameraData
	{
		[SerializeField]
		[VariableProperty("<Value>", typeof(CinemachineBrainVariable))]
		public CinemachineVirtualCameraVariable cinemachineVirtualCameraRef;

		[SerializeField]
		public CinemachineVirtualCamera cinemachineVirtualCameraVal;

		public static implicit operator CinemachineVirtualCamera(CinemachineVirtualCameraData cinemachineVirtualCameraData)
		{
			return cinemachineVirtualCameraData.Value;
		}

		public CinemachineVirtualCameraData(CinemachineVirtualCamera v)
		{
			cinemachineVirtualCameraVal = v;
			cinemachineVirtualCameraRef = null;
		}

		public CinemachineVirtualCamera Value
		{
			get { return (cinemachineVirtualCameraRef == null) ? cinemachineVirtualCameraVal : cinemachineVirtualCameraRef.Value; }
			set { if (cinemachineVirtualCameraRef == null) { cinemachineVirtualCameraVal = value; } else { cinemachineVirtualCameraRef.Value = value; } }
		}

		public string GetDescription()
		{
			if (cinemachineVirtualCameraRef == null)
			{
				return cinemachineVirtualCameraVal != null ? cinemachineVirtualCameraVal.ToString() : "Null";
			}
			else
			{
				return cinemachineVirtualCameraRef.Key;
			}
		}
	}
}