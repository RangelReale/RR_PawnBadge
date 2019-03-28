using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RR_PawnBadge
{
    [HarmonyPatch(typeof(ColonistBarColonistDrawer), nameof(ColonistBarColonistDrawer.DrawColonist))]
    class RimWorld_ColonistBarColonistDrawer_DrawColonist
    {
        private static void Postfix(UnityEngine.Rect rect, Verse.Pawn colonist, Verse.Map pawnMap, bool highlight, bool reordering)
        {
            CompBadge cb = colonist.GetComp<CompBadge>();
            if (cb == null) return;

            if (cb.badges[0] != "")
            {
                GUI.DrawTexture(new UnityEngine.Rect(rect.x - 15, rect.y - 15, 35, 35),
                    DefDatabase<BadgeDef>.GetNamed(cb.badges[0]).Symbol, ScaleMode.ScaleToFit);
            }

            if (cb.badges[1] != "")
            {
                GUI.DrawTexture(new UnityEngine.Rect(rect.xMax - 15, rect.y - 15, 35, 35),
                    DefDatabase<BadgeDef>.GetNamed(cb.badges[1]).Symbol, ScaleMode.ScaleToFit);
            }
        }
    }
}
