using UnityEngine;
using UnityEditor;
using System.IO;

namespace DN
{
	public static class CreateCSharpClass
	{
		private static string CSharpTemplatePath => Path.Combine(ScriptPath, "Templates/CSharpClassTemplate.cs.txt");
		private static string CSharpInterfaceTemplatePath => Path.Combine(ScriptPath, "Templates/CSharpInterfaceTemplate.cs.txt");
		private static string CSharpBehaviourTemplatePath => Path.Combine(ScriptPath, "Templates/CSharpBehaviourTemplate.cs.txt");

		private static string ScriptPath
		{
			get
			{
				if(scriptPath == null)
				{
					string[] res = System.IO.Directory.GetFiles(Application.dataPath, "CreateCSharpClass.cs", SearchOption.AllDirectories);
					if (res.Length == 0)
					{
						Debug.LogError("Could not find file CreateCSharpClass.cs.");
						return null;
					}
					scriptPath = res[0].Substring(0, res[0].LastIndexOf('\\'));
				}

				return scriptPath;
			}
		}
		private static string scriptPath;

		private const int priority = 51;

		[MenuItem("Assets/Create/C# Class", priority = priority)]
		public static void CreateClass()
		{
			ProjectWindowUtil.CreateScriptAssetFromTemplateFile(CSharpTemplatePath, "NewClass.cs");
		}

		[MenuItem("Assets/Create/C# Monobehaviour", priority = priority)]
		public static void CreateMonobehaviour()
		{
			ProjectWindowUtil.CreateScriptAssetFromTemplateFile(CSharpBehaviourTemplatePath, "BehaviourScript.cs");
		}

		[MenuItem("Assets/Create/C# Interface", priority = priority)]
		public static void CreateInterface()
		{
			ProjectWindowUtil.CreateScriptAssetFromTemplateFile(CSharpInterfaceTemplatePath, "InterfaceScript.cs");
		}
	}
}
