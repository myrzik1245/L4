using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets._Project.Code.Editor
{
    public class EntityAPIGenerator
    {
        private const string FieldName = "Value";

        private static string OutputPath
            => Path.Combine(Application.dataPath, "_Project/Code/Runtime/Utility/Generated/EntityAPI.cs");

        private static Type ComponentType => typeof(IEntityComponent);

        [InitializeOnLoadMethod]
        [MenuItem("Tools/GenerateEntityAPI")]
        public static void Generate()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"namespace {typeof(Entity).Namespace}");
            stringBuilder.AppendLine("{");

            stringBuilder.AppendLine($"\tpublic partial class {typeof(Entity).Name}");
            stringBuilder.AppendLine("\t{");

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            Type[] allComponents = GetAllComponents(assemblies);

            foreach (Type type in allComponents)
            {
                string name = type.Name.Replace("Component", "");
                string fullName = type.FullName;

                string componentName = name + "C";

                FieldInfo field = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(field => field.Name == FieldName);

                if (field != null)
                {
                    stringBuilder.AppendLine($"\t\tpublic {GetValidGenericName(type)} {componentName} => GetComponent<{fullName}>();");

                    stringBuilder.AppendLine($"\t\tpublic {GetValidGenericName(field.FieldType)} {name} => {componentName}.{field.Name};");

                    stringBuilder.AppendLine($"\t\tpublic {nameof(Entity)} Add{name}({GetValidGenericName(field.FieldType)} value) => AddComponent(new {GetValidGenericName(type)}() {{ {FieldName} = value }});");

                    stringBuilder.AppendLine();

                }
            }

            stringBuilder.AppendLine("\t}");
            stringBuilder.AppendLine("}");

            File.WriteAllText(OutputPath, stringBuilder.ToString());

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static Type[] GetAllComponents(Assembly[] assemblies)
        {
            return assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsInterface == false
                    && type.IsAbstract == false
                    && ComponentType.IsAssignableFrom(type))
                .ToArray();
        }

        private static string GetValidGenericName(Type type)
        {
            if (type.IsGenericType)
            {
                StringBuilder sb = new StringBuilder();

                string fullTypeName = type.FullName;
                var backtickIndex = fullTypeName.IndexOf('`');

                if (backtickIndex >= 0)
                    fullTypeName = fullTypeName.Substring(0, backtickIndex);

                sb.Append(fullTypeName);
                sb.Append("<");

                Type[] genericArgs = type.GetGenericArguments();

                for (int i = 0; i < genericArgs.Length; i++)
                {
                    if (i > 0)
                        sb.Append(", ");

                    sb.Append(GetValidGenericName(genericArgs[i]));
                }

                sb.Append(">");
                return sb.ToString();
            }
            else
            {
                return type.FullName;
            }
        }
    }
}