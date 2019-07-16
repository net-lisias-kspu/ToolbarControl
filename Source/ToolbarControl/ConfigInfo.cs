using UnityEngine;

namespace ToolbarControl_NS
{
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	public class ConfigInfo : MonoBehaviour
	{
		public static ConfigInfo Instance;
		private static readonly KSPe.IO.Data.ConfigNode DEBUGCFG = KSPe.IO.Data.ConfigNode.ForType<ToolbarControl>("Debug");

		public static bool debugMode
		{
			get { return (Log.LEVEL.TRACE == Log.Level);  }
			set { Log.Level = value ? Log.LEVEL.TRACE : Log.LEVEL.INFO; }
		}

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

			Log.Level =  (node.HasValue("logLevel")) 
				? (Log.LEVEL)int.Parse(node.GetValue("logLevel"))
#if DEBUG
				: Log.LEVEL.DETAIL
#else
				: Log.LEVEL.Info
#endif
				;
		}
	}
}
