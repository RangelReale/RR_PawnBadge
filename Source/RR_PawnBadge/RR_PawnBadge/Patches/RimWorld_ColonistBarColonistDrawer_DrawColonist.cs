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

        private static void Postfix(UnityEngine.Rect rect, Verse.Pawn colonist, Verse.Map pawnMap, bool highlight, bool reordering)
        {
            CompBadge cb = colonist.GetComp<CompBadge>();
            if (cb == null) return;

            float iwidth = ICON_WIDTH;
            switch (Settings.badgeSize)
            {
            case Settings.BadgeSize.Small:
                iwidth = iwidth - 10f;
                break;
            case Settings.BadgeSize.Large:
                iwidth = iwidth + 10f;
                break;
            }
            float iwidth_half = iwidth / 2f;

            if (cb.badges[0] != "")
            {
                GUI.DrawTexture(new UnityEngine.Rect(rect.x - iwidth_half, rect.y - iwidth_half, iwidth, iwidth),
                    DefDatabase<BadgeDef>.GetNamed(cb.badges[0]).Symbol, ScaleMode.ScaleToFit);
            }

            if (cb.badges[1] != "")
            {
                GUI.DrawTexture(new UnityEngine.Rect(rect.xMax - iwidth_half, rect.y - iwidth_half, iwidth, iwidth),
                    DefDatabase<BadgeDef>.GetNamed(cb.badges[1]).Symbol, ScaleMode.ScaleToFit);
            }
        }
    }
}
