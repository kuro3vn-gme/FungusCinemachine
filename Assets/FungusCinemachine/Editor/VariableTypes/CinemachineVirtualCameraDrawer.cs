using UnityEditor;
using Fungus.EditorUtils;
using FungusExtensions.Cinemachine;

namespace FungusExtensions.EditorUtils.Cinemachine
{
	[CustomPropertyDrawer(typeof(CinemachineVirtualCameraData))]
	public class CinemachineVirtualCameraDataDrawer : VariableDataDrawer<CinemachineVirtualCameraVariable> { }
}