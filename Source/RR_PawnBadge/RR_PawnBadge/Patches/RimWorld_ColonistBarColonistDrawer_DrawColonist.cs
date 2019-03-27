using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR_PawnBadge
{
    [HarmonyPatch(typeof(ColonistBarColonistDrawer), nameof(ColonistBarColonistDrawer.DrawColonist))]
    class RimWorld_ColonistBarColonistDrawer_DrawColonist
    {
        private static void Postfix(UnityEngine.Rect rect, Verse.Pawn colonist, Verse.Map pawnMap, bool highlight, bool reordering)
        {

        }
    }
}
