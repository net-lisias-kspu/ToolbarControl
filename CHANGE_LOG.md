# Toolbar Controller :: Change Log

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
