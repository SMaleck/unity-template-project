using Source.Frameworks;
using UnityEngine;
using Zenject;

namespace Source.Installation
{
    [CreateAssetMenu(fileName = nameof(DataScriptableObjectInstaller), menuName = Constants.InstallersMenu + nameof(DataScriptableObjectInstaller))]
    public class DataScriptableObjectInstaller : ScriptableObjectInstaller<DataScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}