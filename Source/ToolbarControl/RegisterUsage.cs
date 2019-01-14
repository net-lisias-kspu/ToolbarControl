using System.Collections.Generic;
using KSPe;

namespace ToolbarControl_NS
{
    public partial class ToolbarControl
    {
        internal class Mod
        {
            public string modId;
            public string displayName;
            public bool useBlizzy;
            public bool useStock;
            public bool noneAllowed = true;
            public ToolbarControl modToolbarControl;
            public bool registered = false;

            public Mod(string ModId, string DisplayName, bool UseBlizzy, bool UseStock, bool NoneAllowed = true)
            {
                modId = ModId;
                displayName = DisplayName;
                useBlizzy = UseBlizzy;
                useStock = UseStock;

                noneAllowed = NoneAllowed;
            }
        }

        //internal static SortedDictionary<string, Mod> registeredMods = new SortedDictionary<string, Mod>();

        internal static Dictionary<string, Mod> registeredMods = new Dictionary<string, Mod>();
        internal static List<Mod> sortedModList = new List<Mod>();

		//internal static List<Mod> registeredMods = new List<Mod>();

		private const string TOOLBARCONTROL = "ToolbarControl";
		private const string TOOLBARCONTROLDATA = "ToolbarControlData";
		private const string DATA = "DATA";
		private static bool initted = false;

		private static KSPe.IO.Data.ConfigNode CONFIG = KSPe.IO.Data.ConfigNode.ForType<ToolbarControl>(TOOLBARCONTROLDATA, TOOLBARCONTROL+".cfg");
        internal static void SaveData()
        {
			CONFIG.Clear();

            CONFIG.Node.AddValue("showWindowAtStartup", IntroWindowClass.showIntroAtStartup);
            foreach (KeyValuePair<string, Mod> s in registeredMods)
            {
                ConfigNode nodeData = new ConfigNode();
                nodeData.AddValue("name", s.Key);
                nodeData.AddValue("displayName", s.Value.displayName);
                nodeData.AddValue("useBlizzy", s.Value.useBlizzy);
                nodeData.AddValue("useStock", s.Value.useStock);
                nodeData.AddValue("noneAllowed", s.Value.noneAllowed);
                
                CONFIG.Node.AddNode(DATA, nodeData);
            }
			CONFIG.Save();
        }

		private static bool ToBool(string aText)
        {
			return aText != null && aText.ToLower() == "true" || aText.ToLower() == "on" || aText.ToLower() == "yes";
		}

		internal static void LoadData()
        {
            if (initted)
                return;
            if (CONFIG.IsLoadable)
            {
				ConfigNodeWithSteroids data = CONFIG.Load().NodeWithSteroids;
                initted = true;

                registeredMods.Clear();
                if (data.HasValue("showWindowAtStartup"))
                {
                    IntroWindowClass.showIntroAtStartup = data.GetValue<bool>("showWindowAtStartup");
                }

                foreach (ConfigNode node in data.GetNodes())
                {
                    if (node.HasValue("name") && node.HasValue("useBlizzy"))
                    {
                        string modName = node.GetValue("name");
                        string displayName = modName;
                        try
                        {
                            displayName = node.GetValue("displayName");
                            if (displayName == "")
                                displayName = modName;
                        }
                        catch { }
                        bool useBlizzy = ToBool(node.GetValue("useBlizzy"));
                        bool useStock = true;
                        if (node.HasValue("useStock"))
                            useStock = ToBool(node.GetValue("useStock"));

                        bool noneAllowed = true;
                        if (node.HasValue("noneAllowed"))
                            noneAllowed = ToBool(node.GetValue("noneAllowed"));

                        Mod mod = new Mod(modName, displayName, useBlizzy, useStock, noneAllowed);
                        registeredMods.Add(modName, mod);
                        // sortedModList.Add(mod);
                    }
                    //sortedModList.Sort((x, y) => x.displayName.CompareTo(y.displayName));
                }
            }
        }

        public static bool RegisterMod(string NameSpace, string DisplayName = "", bool useBlizzy = false, bool useStock = true, bool NoneAllowed = true)
        {
            if (BlizzyOptions.startupCompleted)
            {
                Log.Warning("RegisterMod, LoadedScene: " + HighLogic.LoadedScene + ", called too late for: " + NameSpace + ", " + DisplayName + ", button may not be registered properly");
            }
            LoadData();
            Mod mod = null;
            //Log.Info("RegisterMod, NameSpace: " + NameSpace + ", DisplayName: " + DisplayName);
            if (registeredMods.ContainsKey(NameSpace))
            {
                //Log.Info("RegisterMod, found, NameSpace: " + NameSpace + ", DisplayName: " + DisplayName);
                if (DisplayName != "")
                    registeredMods[NameSpace].displayName = DisplayName;

                registeredMods[NameSpace].noneAllowed = NoneAllowed;
                registeredMods[NameSpace].registered = true;
                mod = registeredMods[NameSpace];
                SaveData();

            }
            else
                try
                {
                    if (DisplayName == "")
                        DisplayName = NameSpace;
                    //Log.Info("RegisterMod, NameSpace: " + NameSpace + ", DisplayName: " + DisplayName);
                    mod = new Mod(NameSpace, DisplayName, useBlizzy, useStock, NoneAllowed);
                    registeredMods.Add(NameSpace, mod);

                    SaveData();

                }
                catch { return false; }
            if (mod != null)
            {
                sortedModList.Add(mod);

                sortedModList.Sort((x, y) => x.displayName.CompareTo(y.displayName));

                return true;
            }
            // Should never get here
            Log.Error("Impossible Error");
            return false;
        }


        public static bool BlizzyActive(string NameSpace, bool? useBlizzy = null)
        {
            LoadData();

            if (useBlizzy == null)
            {

				return registeredMods.ContainsKey(NameSpace) && registeredMods[NameSpace].useBlizzy;
			}

			registeredMods[NameSpace].useBlizzy = (bool)useBlizzy;
            SaveData();
            return (bool)useBlizzy;
        }

        public static bool StockActive(string NameSpace, bool? useStock = null)
        {
            LoadData();
            if (useStock == null)
            {
				return registeredMods.ContainsKey(NameSpace) && registeredMods[NameSpace].useStock;
			}

			registeredMods[NameSpace].useStock = (bool)useStock;
            SaveData();
            return (bool)useStock;
        }

        public static void ButtonsActive(string NameSpace, bool? useStock, bool? useBlizzy)
        {
            LoadData();

            registeredMods[NameSpace].useStock = (bool)useStock;
            registeredMods[NameSpace].useBlizzy = (bool)useBlizzy;
            SaveData();
        }
    }
}
