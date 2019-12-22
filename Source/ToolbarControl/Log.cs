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

		internal static LEVEL Level {
			get => (LEVEL)logger.level;
			set => logger.level = (L.Level)value;
		}

		public static void Trace(String msg)
		{
			logger.trace(msg);
		}

		public static void Trace(String formatstr, params object[] parms)
		{
			logger.trace(formatstr, parms);
		}

		public static void Detail(String msg)
		{
			logger.detail(msg);
		}

		public static void Info(String msg)
		{
			logger.info(msg);
		}

		public static void Warning(String msg)
		{
			logger.warn(msg);
		}

		public static void Error(String msg)
		{
			logger.error(msg);
		}

		public static void Error(Exception ex, String formatstr, params object[] parms)
		{
			logger.error(ex, formatstr, parms);
		}

		[ConditionalAttribute("DEBUG")]
		public static void Debug(String msg)
		{
			logger.trace(msg);
		}

		[ConditionalAttribute("DEBUG")]
		public static void Debug(String formatstr, params object[] parms)
		{
			logger.trace(formatstr, parms);
		}

		public static void Force(String msg)
		{
			logger.force(msg);
		}

		public static void Force(String formatstr, params object[] parms)
		{
			logger.force(formatstr, parms);
		}

		public static void Exception(Exception e)
		{
			logger.error(e, "");
		}

	}
}
