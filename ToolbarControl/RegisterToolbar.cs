﻿using System;
using UnityEngine;
using KSP.UI.Screens;
using ClickThroughFix;
using System.Linq;

namespace ToolbarControl_NS
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class RegisterToolbarBlizzyOptions : MonoBehaviour
    {

        public void Awake()
        {
            ToolbarControl.RegisterMod(BlizzyOptions.MODID, BlizzyOptions.MODNAME, false, true, false);
        }
    }
}