using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RR_PawnBadge
{
    public class Settings : ModSettings
    {
        public enum BadgePosition : byte
        {
            Top             = 1,
            Left            = 2,
            Right           = 3,
            Bottom          = 4,
        };

        public enum BadgeSize : byte
        {
            Small           = 1,
            Medium          = 2,
            Large           = 3,
        }

        public static BadgePosition badgePosition = BadgePosition.Top;
        public static BadgeSize badgeSize = BadgeSize.Medium;

        public void DoWindowContents(Rect canvas)
        {
            Listing_Standard list = new Listing_Standard();
            list.ColumnWidth = canvas.width;
            list.Begin(canvas);

            // badge position setting
            list.Label("PawnBadge.BadgePosition".Translate());
            list.GapLine();
            if (list.RadioButton("PawnBadge.BadgePosition_Top".Translate(), badgePosition == BadgePosition.Top, 0f, null))
            {
                badgePosition = BadgePosition.Top;
            }
            if (list.RadioButton("PawnBadge.BadgePosition_Left".Translate(), badgePosition == BadgePosition.Left, 0f, null))
            {
                badgePosition = BadgePosition.Left;
            }
            if (list.RadioButton("PawnBadge.BadgePosition_Right".Translate(), badgePosition == BadgePosition.Right, 0f, null))
            {
                badgePosition = BadgePosition.Right;
            }
            if (list.RadioButton("PawnBadge.BadgePosition_Bottom".Translate(), badgePosition == BadgePosition.Bottom, 0f, null))
            {
                badgePosition = BadgePosition.Bottom;
            }
            list.Gap();

            // badge size setting
            list.Label("PawnBadge.BadgeSize".Translate());
            list.GapLine();
            if (list.RadioButton("PawnBadge.BadgeSize_Small".Translate(), badgeSize == BadgeSize.Small, 0f, null))
            {
                badgeSize = BadgeSize.Small;
            }
            if (list.RadioButton("PawnBadge.BadgeSize_Medium".Translate(), badgeSize == BadgeSize.Medium, 0f, null))
            {
                badgeSize = BadgeSize.Medium;
            }
            if (list.RadioButton("PawnBadge.BadgeSize_Large".Translate(), badgeSize == BadgeSize.Large, 0f, null))
            {
                badgeSize = BadgeSize.Large;
            }

            list.End();
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<BadgePosition>(ref badgePosition, "badgePosition", BadgePosition.Top);
            Scribe_Values.Look<BadgeSize>(ref badgeSize, "badgeSize", BadgeSize.Medium);
        }
    }
}
