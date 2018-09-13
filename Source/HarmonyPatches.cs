/*
 * User: Phomor
 * Date: 06.09.2018
 * Time: 16:32
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
	
	[HarmonyPatch(typeof(Building_Door))]
	[HarmonyPatch("Tick")]
	static class HarmonyPatches
	{
		public static int newTicksUntilClose = 59;
		
		[HarmonyPostfix]
		public static void Postfix(ref int ___ticksUntilClose)
		{
			if(___ticksUntilClose == 109)
			{
				___ticksUntilClose = newTicksUntilClose;
			}
		}
	}
}
