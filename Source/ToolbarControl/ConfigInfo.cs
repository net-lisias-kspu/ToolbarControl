using UnityEngine;

namespace ToolbarControl_NS
{
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	public class ConfigInfo : MonoBehaviour
	{
		public static ConfigInfo Instance;
		private static readonly KSPe.IO.Data.ConfigNode DEBUGCFG = KSPe.IO.Data.ConfigNode.ForType<ToolbarControl>("Debug");

		static public bool debugMode = false;

		public void Start()
		{
			Instance = this;
			LoadData();
			DontDestroyOnLoad(this);
		}

		public void SaveData()
		{
			ConfigNode settingsFile = new ConfigNode();
			ConfigNode settings = new ConfigNode();

			settingsFile.SetNode(Settings.SETTINGSNAME, settings, true);
			settings.AddValue("debugMode", HighLogic.CurrentGame.Parameters.CustomParams<TC>().debugMode);

			DEBUGCFG.Save(settingsFile);
		}

		public void LoadData()
		{
			if (!DEBUGCFG.IsLoadable) return;

			ConfigNode node = DEBUGCFG.Load().Node;
			if (node.HasValue("debugMode"))
				debugMode = bool.Parse(node.GetValue("debugMode"));
			if (debugMode)	Log.Force("Debug is activated");

			if (node.HasValue("logLevel"))
				Log.Level = (Log.LEVEL)int.Parse(node.GetValue("logLevel"));
		}
	}
}
