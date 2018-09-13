﻿/*
 * User: Phomor
 * Date: 06.09.2018
 * Time: 16:36
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Reflection;
using Harmony;
using UnityEngine;
using Verse;
using RimWorld;

namespace DoorsCloseFastAgain
{
	/// <summary>
	/// Doors close faster after a pawn went through.
	/// </summary>
	public class Controller : Mod
	{
		public Settings settings;
		
		public Controller(ModContentPack content) : base (content)
		{
			var harmony = HarmonyInstance.Create("rimworld.phomor.doorsclosefastagain");
			var original = typeof(Building_Door).GetMethod("Tick");
			var postfix = typeof(HarmonyPatches).GetMethod("Postfix");
			harmony.Patch(original, null, new HarmonyMethod(postfix));
			settings = GetSettings<Settings>();
			updatePatches();
		}
		
		public override string SettingsCategory()
		{
			return "DoorsCloseFastAgain".Translate();
		}
		
		public override void DoSettingsWindowContents(Rect inRect)
		{
			settings.DoWindowContents(inRect);
			updatePatches();
		}
		
		public void updatePatches()
		{
			HarmonyPatches.newTicksUntilClose = settings.newTicksUntilClose - 1;
		}
	}
}