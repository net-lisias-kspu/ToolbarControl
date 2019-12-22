using UnityEngine;

namespace ToolbarControl_NS
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    internal class Startup : MonoBehaviour
	{
        private void Start()
        {
            Log.Force("Version {0}", Version.Text);

            try
            {
                KSPe.Util.Installation.Check<Startup>("001_ToolbarControl");
            }
            catch (KSPe.Util.InstallmentException e)
            {
                Log.Exception(e);
				KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
			}
        }
	}
}
