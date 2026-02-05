using System.IO;
using System.Text;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Assets._Project.Code.Editor
{
    public class LayerGenerator
    {
        private static string OutputPath
            => Path.Combine(Application.dataPath, "_Project/Code/Runtime/Utility/Generated/UnityLayers.cs");

        [MenuItem("Tools/Generate Layer Constants")]
        public static void Generate()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("public static class UnityLayers");
            stringBuilder.AppendLine("{");

            foreach (string layer in InternalEditorUtility.layers)
            {
                string name = layer.Replace(" ", "");
                stringBuilder.AppendLine($"\tpublic static readonly int Layer{name} = UnityEngine.LayerMask.NameToLayer(\"{layer}\");");
                stringBuilder.AppendLine($"\tpublic static readonly int LayerMask{name} = 1 << Layer{name};");
                stringBuilder.AppendLine();
            }

            stringBuilder.AppendLine("}");

            File.WriteAllText(OutputPath, stringBuilder.ToString());

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }
    }
}