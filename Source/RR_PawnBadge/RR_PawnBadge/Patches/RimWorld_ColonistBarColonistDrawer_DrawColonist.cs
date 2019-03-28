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
        const float ICON_WIDTH = 35f;
        const float ICON_WIDTH_HALF = 35f / 2f;

        private static void Postfix(UnityEngine.Rect rect, Verse.Pawn colonist, Verse.Map pawnMap, bool highlight, bool reordering)
        {
            CompBadge cb = colonist.GetComp<CompBadge>();
            if (cb == null) return;

            if (cb.badges[0] != "")
            {
                GUI.DrawTexture(new UnityEngine.Rect(rect.x - ICON_WIDTH_HALF, rect.y - ICON_WIDTH_HALF, ICON_WIDTH, ICON_WIDTH),
                    DefDatabase<BadgeDef>.GetNamed(cb.badges[0]).Symbol, ScaleMode.ScaleToFit);
            }

            if (cb.badges[1] != "")
            {
                GUI.DrawTexture(new UnityEngine.Rect(rect.xMax - ICON_WIDTH_HALF, rect.y - ICON_WIDTH_HALF, ICON_WIDTH, ICON_WIDTH),
                    DefDatabase<BadgeDef>.GetNamed(cb.badges[1]).Symbol, ScaleMode.ScaleToFit);
            }
        }
    }
}
