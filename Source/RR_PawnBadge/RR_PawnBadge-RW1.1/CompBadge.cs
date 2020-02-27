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
            this.badges = new string[] { "", "" };
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            bool isSave = Scribe.mode == LoadSaveMode.Saving;

            if (!isSave || this.badges[0] != "")
            {
                Scribe_Values.Look<string>(ref this.badges[0], "RRPawnBadge_Badge0", defaultValue: "");
            }
            if (!isSave || this.badges[1] != "")
            {
                Scribe_Values.Look<string>(ref this.badges[1], "RRPawnBadge_Badge1", defaultValue: "");
            }
        }

        public string[] badges;
    }
}
