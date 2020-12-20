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
                KSPe.Util.Installation.Check<Startup>("ToolbarControl", "001_ToolbarControl", null);
            }
            catch (KSPe.Util.InstallmentException e)
            {
                Log.Exception(this, e);
				KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
			}
        }
	}
}
