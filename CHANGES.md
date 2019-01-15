# Toolbar Controller :: Changes

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
