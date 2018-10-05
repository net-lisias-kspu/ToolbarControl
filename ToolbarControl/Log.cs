using System;
using System.Diagnostics;

using L = KSPe.Util.Log;

namespace ToolbarControl_NS
{
    internal static class Log
    {
        public enum LEVEL
        {
            OFF = L.Level.OFF,
            ERROR = L.Level.ERROR,
            WARNING = L.Level.WARNING,
            INFO = L.Level.INFO,
            DETAIL = L.Level.DETAIL,
            TRACE = L.Level.TRACE
        };
        
		private static readonly L.Logger logger = L.Logger.CreateForType<ToolbarControl>("ToolbarControl");

		public static void SetLevel(LEVEL level)
		{
			logger.level = (L.Level)level;
            Log.Force(string.Format("Log is active to level {0}", level));
		}

		public static LEVEL GetLevel()
		{
			return (LEVEL)logger.level;
		}

        public static void Trace(String msg)
        {
			logger.trace(msg);
        }

        public static void Detail(String msg)
        {
			logger.detail(msg);
        }

        public static void Info(String msg)
        {
			logger.info(msg);
        }

        public static void Test(String msg)
        {
			if (ConfigInfo.debugMode)
				logger.force("TEST: " + msg);
        }

        public static void Warning(String msg)
        {
			logger.warn(msg);
        }

        public static void Error(String msg)
        {
			logger.error(msg);
        }

        public static void Debug(String msg)
        {
	        logger.trace(msg);
        }

		public static void Force(String msg)
        {
	        logger.force(msg);
        }

        public static void Exception(Exception e)
        {
			logger.error(e, "");
        }

    }
}
