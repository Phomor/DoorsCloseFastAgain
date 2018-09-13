/*
 * User: Phomor
 * Date: 13.09.2018
 * Time: 16:06
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
	public class Settings : Verse.ModSettings
	{
		public int newTicksUntilClose = 60;
		
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref newTicksUntilClose, "newticksuntilclose", 60);
		}
		
		public void DoWindowContents(Rect inRect)
		{
			{
				var list = new Listing_Standard();
				Color defaultCOlor = GUI.color;
				list.Begin(inRect);
				
				list.Label("DoorsCloseFastAgain.TickExplanation".Translate());
				
				list.Label("DoorsCloseFastAgain.NewTicksUntilClose".Translate() + newTicksUntilClose);
				newTicksUntilClose = (int) list.Slider(newTicksUntilClose, 2, 109);
				
				list.End();
			}
		}
	}
}
