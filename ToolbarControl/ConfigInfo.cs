using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.UI.Screens;
using KSP.IO;

namespace ToolbarControl_NS
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class ConfigInfo : MonoBehaviour
    {
        public static ConfigInfo Instance;
		static readonly string DEBUGCFG = Path.Combine(Settings.PLUGINDATA,"Debug.cfg");

        static public bool debugMode = false;

        void Start()
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

			if (!Directory.Exists(Settings.PLUGINDATA)) Directory.CreateDirectory(Settings.PLUGINDATA);
			settingsFile.Save(DEBUGCFG);
        }

        public void LoadData()
        {
            ConfigNode settingsFile = ConfigNode.Load(Settings.PLUGINDATA);
            ConfigNode node = null;
            if (settingsFile != null)
            {
                node = settingsFile.GetNode(Settings.SETTINGSNAME);
                if (node != null)
                {
                    if (node.HasValue("debugMode"))
                    {
                        debugMode = bool.Parse(node.GetValue("debugMode"));
                    }
                }
            }
            
        }
    }
}
