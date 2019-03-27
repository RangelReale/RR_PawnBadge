using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RR_PawnBadge
{
    class CompBadge : ThingComp
    {
        public CompBadge()
        {
            this.badgeA = -1;
            this.badgeB = -1;
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
        }

        public int badgeA;
        public int badgeB;
    }
}
