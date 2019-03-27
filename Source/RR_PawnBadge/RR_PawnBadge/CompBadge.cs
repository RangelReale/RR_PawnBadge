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
            this.badgeA = "";
            this.badgeB = "";
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
        }

        public string badgeA;
        public string badgeB;
    }
}
