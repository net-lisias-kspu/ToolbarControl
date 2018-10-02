﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.UI.Screens;
using KSPe;

namespace ToolbarControl_NS
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class ConfigInfo : MonoBehaviour
    {
        public static ConfigInfo Instance;
		static readonly PluginConfig DEBUGCFG = PluginConfig.ForType<ToolbarControl>("Debug");

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

			DEBUGCFG.Save(settingsFile);
        }

        public void LoadData()
        {
			if (!DEBUGCFG.IsLoadable) return;
			
            ConfigNode node = DEBUGCFG.Load().Node;
            if (node.HasValue("debugMode"))
                debugMode = bool.Parse(node.GetValue("debugMode"));
            if (debugMode)  Log.Force("Debug is activated");

            if (node.HasValue("logLevel"))
                Log.SetLevel((Log.LEVEL)int.Parse(node.GetValue("logLevel")));
            if (Log.LEVEL.OFF != Log.GetLevel())
                Log.Force(string.Format("Log is active to level {0}", Log.GetLevel()));
        }
    }
}
