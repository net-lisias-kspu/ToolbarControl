using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ToolbarControl /L Unofficial")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ToolbarControl")]
[assembly: AssemblyCopyright("Copyright © 2019 LinuxGuruGamer, LisiasT")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("b146b9f2-61cb-4e43-bf7c-8737448116ae")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
//[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion(ToolbarControl_NS.Version.Number)]
[assembly: AssemblyVersion(ToolbarControl_NS.Version.Number)]

//[assembly: KSPAssembly("ToolbarController", ToolbarControl_NS.Version.major, ToolbarControl_NS.Version.minor)]
[assembly: KSPAssembly("ToolbarController", 1, 0)] // Preventing breaking dependences keeping it at part to upstream
[assembly: KSPAssemblyDependency("KSPe", 2, 1)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 1)]
