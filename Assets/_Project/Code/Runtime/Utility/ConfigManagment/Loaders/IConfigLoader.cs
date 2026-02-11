using System;
using System.Collections;

namespace Assets._Project.Code.Runtime.Utility.ConfigManagment.Loaders
{
    public interface IConfigLoader
    {
        IEnumerator LoadAsync(Action<Type, object> onLoad);
    }
}