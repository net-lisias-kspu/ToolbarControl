# Toolbar Controller :: Change Log

* 2020-1221: 0.1.9.6 (lisias) for KSP >= 1.4.1
	+ Update needed by a KSPe API change.
	+ Adding some convenience methods KSPe style.
* 2019-1222: 0.1.9.5 (lisias) for KSP >= 1.4.1
	+ Catching up to upstream
	+ Better overall log messages
	+ Using KSPe Instalment checks
	+ Certified to work on KSP 1.8.x
* 2019-0723: 0.1.8.2 (lisias) for KSP >= 1.4.1
	+ Merging upstream new features
		- Updated to add large icon to the toolbar.BigTexturePath (new in toolbar 1.7.20)
		- Added InstallChecker
	+ Adding KSPe UI Facilities
	+ Adding KSPe Image facilities
	+ Bumping up version to catch up with upstream's
	+ Certified to work on KSP 1.5.x , 1.6.x and 1.7.x series.
* 2019-0629: 0.1.7.1 (lisias) for KSP >= 1.4.1
	+ Bumping up version to catch up with upstream's, and avoid being kicked out by new Add'Ons relying on the DLL version for compatibility
	+ Changing a public method's signature to keep it synced with upstream (that changed it)
* 2019-0427: 0.1.6.21 (lisias) for KSP >= 1.4.1
	+ Bumping up version to catch up with upstream's, and avoid being kicked out by new Add'Ons relying on the DLL version for compatibility
	+ Properly naming the think as '/L Unofficial'
	+ Simplifying KSP versioning control
	+ Properly stating compatibility to KSP 1.4.1 and above, as I don't test it on 1.4.0 and below.
* 2019-0115: 0.1.6.18 (lisias) for KSP >= 1.4
	+ Adding KSPe as hard dependency
		- Using logging facilities
		- Using Data files facilities
	+ Fixing an warning on the initialization process.  
	+ Removed ClickThroughBlocker dependency
	+ Bumping version to match upstream's
	+ Adding a proper [INSTALL](https://github.com/net-lisias-kspu/ToolbarControl/blob/master/INSTALL.md) instructions.
* 2018-1001: 0.1.6.16 (lisias) for KSP 1.4.1
	+ Using [KSPe](https://github.com/net-lisias-ksp/KSPAPIExtensions) for PluginData access.
	+ Some love to Logging.
	+ Merging upstream fixes:
		-  Fixed nullref which was occuring in some mods at initialization
* 2018-0827: 0.1.6.15 (lisias) for KSP 1.4.1
	+ Merging upstream fixes:
		- Fixed timing issue on toolbar registration
		- Added log warning in case RegisterToolbar is called too late
		- Log fixes from PiezPiedPy (but not the path fixes)
		- Log fixes from LGG
* 2018-0808: 0.1.6.14 (lisias) for KSP 1.4.1
	+ Moving settings/configuration file to <KSP_ROOT>/PluginData
* 2018-0807: 0.1.6.13 (linuxgurugamer) for KSP 1.4.1
	+ Reimplemented the Log.Debug, using a local file to store the debug value
* 2018-0805: 0.1.6.12 (linuxgurugamer) for KSP 1.4.1
	+ Commented out all Log.Debug lines because they were using the settings class which isn't instantiated in the beginning.  Was causing nullrefs
* 2018-0805: 0.1.6.11 (linuxgurugamer) for KSP 1.4.1
	+ Added a debugMode setting
	+ Changed most Log.info to Log.Debug to reduce log spam
* 2018-0621: 0.1.6.10 (linuxgurugamer) for KSP 1.4.1
	+ Fixed Nullref when Blizzy toolbar not installed and buttons were selected to be on the Blizzy button
* 2018-0608: 0.1.6.9 (linuxgurugamer) for KSP 1.4.1
	+ Added code to load button textures from game database instead of the disk for the stock toolbar
* 2018-0513: 0.1.6.7 (linuxgurugamer) for KSP 1.4.1
	+ Fixed repaint issues causing NullRefs
	+ Now only shows mods which have regeristed in the current game, it still remembers all of them
* 2018-0504: 0.1.6.6 (linuxgurugamer) for KSP 1.4.1
	+ Added IsHovering
	+ Added StockPosition
	+ Added BlizzyPosition ( placeholder for now)
	+ Changed startup for registeration from MainMenu to instantly
	+ Added sorted list by mod id
	+ Reduced size of ToolbarController window
	+ Added two new methods:
		- bool IsStockButtonManaged(ApplicationLauncherButton button, out string nameSpace, out string id, out string toolTip)
		- bool IsBlizzyButtonManaged(IButton blizzyButton, out string nameSpace, out string id, out string toolTip)
* 2018-0425: 0.1.6.5 (linuxgurugamer) for KSP 1.4.1
	+ Fixed issue when both buttons are shown, if the mod was updating the textures, the stock texture wasn't being updated while the Blizzy texture was
* 2018-0419: 0.1.6.4 (linuxgurugamer) for KSP 1.4.1
	+ Added two methods, currently only working on the stock button:
		- public void DisableMutuallyExclusive()
		- public void EnableMutuallyExclusive()
	+ Fixed hovering over button in Blizzy toolbar not working
* 2018-0415: 0.1.6.3 (linuxgurugamer) for KSP 1.4.1
	+ Fixed nullrefs when blizzy toolbar not installed
	+ Added code to always show buttons on stock if lbizzy not installed
* 2018-0415: 0.1.6.2 (linuxgurugamer) for KSP 1.4.1
	+ Fixed nullref when setting textures and no stock button set
* 2018-0414: 0.1.6.1 (linuxgurugamer) for KSP 1.4.1
	+ Added KSPAssembly to AssemblyInfo.cs, will help with load order of DLLs
* 2018-0413: 0.1.6 (linuxgurugamer) for KSP 1.4.1
	+ Added code for mods to register with the toolbar Controller
	+ Added functions for mods to set and get the setting for the Blizzy toolbar
	+ Added window to allow users to change setting without having to go into the mod
	+ Added following methods, see the README for details:
			- toolbarControl.UseButtons(string NameSpace);
		- public static bool RegisterMod(string NameSpace, string DisplayName = "", bool useBlizzy = false, bool useStock = true, bool NoneAllowed = true)
		- public static bool BlizzyActive(string NameSpace, bool? useBlizzy = null)
		- public static bool StockActive(string NameSpace, bool? useStock = null)
		- public static void ButtonsActive(string NameSpace, bool? useStock, bool? useBlizzy)
		- public void UseStock(bool useStock)
	+ Cleaned up old commented-out code
* 2018-0403: 0.1.5.9 (linuxgurugamer) for KSP 1.4.1
	+ Fixed issue when doing a SetTrue or SetFalse before the button has actually been created
* 2018-0403: 0.1.5.8 (linuxgurugamer) for KSP 1.4.1
	+ Updated version file for 1.4.1-1.4.99
* 2018-0326: 0.1.5.7 (linuxgurugamer) for KSP 1.4.1
	+ fixed the LoadImageFromFile, the "public" was deleted somehow
* 2018-0324: 0.1.5.6 (linuxgurugamer) for KSP 1.4.1
	+ Added DDS to the possible image formats, only DXT1 and DXT5 are supported
* 2018-0320: 0.1.5.5 (linuxgurugamer) for KSP 1.4.1
	+ Added GIF to the possible image formats
* 2018-0319: 0.1.5.4 (linuxgurugamer) for KSP 1.4.1
	+ Fix for fuzzy buttons
* 2018-0318: 0.1.5.3 (linuxgurugamer) for KSP 1.4.1
	+ Fixed nullref when onTrue was called before button was created
* 2018-0316: 0.1.5.2 (linuxgurugamer) for KSP 1.4.1
	+ Fixed AddLeftRightClickCallbacks call
* 2018-0316: 0.1.5.1 (linuxgurugamer) for KSP 1.4.1
	+ Filled nullref when first called
	+ Fixed bug when a mod called SetTrue or SetFalse, the button would be set true/false, but the texture wasn't being changed
* 2018-0314: 0.1.5 (linuxgurugamer) for KSP 1.4.1
	+ Updated for 1.4.1
* 2018-0222: 0.1.4.7 (linuxgurugamer) for KSP 1.4.0
	+ Fixed bug with not being able to have a button on the Blizzy toolbar only in the flight scene and not in the map view
	+ Added void SetTexture(string large, string small) to allow mod to change the button textures directly
* 2018-0128: 0.1.4.6 (linuxgurugamer) for KSP 1.4.0
	+ Added code to not try to use tooltips if not in a scene which supports it
* 2018-0126: 0.1.4.5 (linuxgurugamer) for KSP 1.4.0
	+ Fixed typo in the UseBlizzy method which was causing the blizzy toolbar to be always selected if it was called before the initial button creation
* 2018-0125: 0.1.4.4 (linuxgurugamer) for KSP 1.4.0
	+ Improved the UseBlizzy method to now allow setting it BEFORE creating the toolbar, this makes it possible to not have to use the UseBlizzy in an OnGUI if not desired
	+ Added methods:  SetTrue() and SetFalse()
* 2018-0124: 0.1.4.3 (linuxgurugamer) for KSP 1.4.0
	+ Added method/function to allow mods to check to see if a toolbarbutton is controlled by this mod
	+ Renamed License.md and README.md
* 2018-0123: 0.1.4.1 (linuxgurugamer) for KSP 1.4.0
	+ Fixed harmless nullrefs which were happening after clicking toolbar button
	+ Added checks to all callbacks for nulls
* 2018-0122: 0.1.4 (linuxgurugamer) for KSP 1.4.0
	+ Added left/right button callbacks
	+ Updated documentation
* 2018-0121: 0.1.3.5 (linuxgurugamer) for KSP 1.4.0
	+ More fixes for multiple buttons
* 2018-0118: 0.1.3.4 (linuxgurugamer) for KSP 1.4.0
	+ Fixed problem where stock toolbar button wasn't being deleted
* 2018-0118: 0.1.3.3 (linuxgurugamer) for KSP 1.4.0
	+ Fixed download link in .version file
* 2018-0118: 0.1.3.2 (linuxgurugamer) for KSP 1.4.0
	+ No changelog provided
* 2018-0116: 0.1.3.1 (linuxgurugamer) for KSP 1.4.0
	+ Moved mod into it's own folder
* 2018-0116: 0.1.3 (linuxgurugamer) for KSP 1.4.0
	+ Fixed nullref during game startup
* 2018-0114: 0.1.2 (linuxgurugamer) for KSP 1.4.0
	+ Fixed issue with stock toolbar not changing textures
	+ Replaced Debug.Log with logging class to reduce log spam
* 2018-0114: 0.1.1 (linuxgurugamer) for KSP 1.4.0
	+ Moved mod into the 000_Toolbar directory
	+ Added method to return location of mouse at last buttonclick
	+ Added Enable method to enable/disable the button
	+ Added tooltip for stock buttons
	+ Added settings page
		- Show tooltips
		- Stock tooltip timeout
* 2018-0112: 0.1.0 (linuxgurugamer) for KSP 1.4.0
	+ Initial release
