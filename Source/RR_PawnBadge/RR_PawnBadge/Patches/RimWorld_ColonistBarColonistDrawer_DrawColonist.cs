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
            float iwidth_half = iwidth / 2.0f;
            float ibottommargin = iwidth_half;

            // default position is Top, adjust starting from this
            if (cb.badges[0] != "")
            {
                Rect brect = new Rect(rect.x - iwidth_half, rect.y - iwidth_half, iwidth, iwidth);
                switch (Settings.badgePosition)
                {
                    case Settings.BadgePosition.Bottom:
                        brect.y += rect.height - ibottommargin;
                        break;
                    case Settings.BadgePosition.Right:
                        brect.x += rect.width;
                        break;
                }
                GUI.DrawTexture(brect, DefDatabase<BadgeDef>.GetNamed(cb.badges[0]).Symbol, ScaleMode.ScaleToFit);
            }

            if (cb.badges[1] != "")
            {
                Rect brect = new Rect(rect.xMax - iwidth_half, rect.y - iwidth_half, iwidth, iwidth);
                switch (Settings.badgePosition)
                {
                    case Settings.BadgePosition.Bottom:
                        brect.y += rect.height - ibottommargin;
                        break;
                    case Settings.BadgePosition.Left:
                        brect.x -= rect.width;
                        brect.y += rect.height - ibottommargin;
                        break;
                    case Settings.BadgePosition.Right:
                        brect.y += rect.height - ibottommargin;
                        break;
                }
                GUI.DrawTexture(brect, DefDatabase<BadgeDef>.GetNamed(cb.badges[1]).Symbol, ScaleMode.ScaleToFit);
            }
        }
    }
}
