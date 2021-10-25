using UnityEditor;
using Fungus.EditorUtils;
using FungusExtensions.Cinemachine;

namespace FungusExtensions.EditorUtils.Cinemachine
{
	[CustomPropertyDrawer(typeof(CinemachineBrainData))]
	public class CinemachineBrainDataDrawer : VariableDataDrawer<CinemachineBrainVariable> { }
}