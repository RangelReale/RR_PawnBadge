using Harmony;
using HugsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RR_PawnBadge
{
    public class Mod : ModBase
    {
        Mod() : base()
        {
            HarmonyInstance.Create("RR_PawnBadge").PatchAll();
        }

        public override string ModIdentifier => "RR_PawnBadge";

        public override void DefsLoaded()
        {
            base.DefsLoaded();

            IEnumerable<ThingDef> things = (
               from def in DefDatabase<ThingDef>.AllDefs
               where def.race?.intelligence == Intelligence.Humanlike
               select def
           );
            foreach (ThingDef t in things)
            {
                // add badge tab to pawns
                if (t.inspectorTabsResolved == null)
                {
                    t.inspectorTabsResolved = new List<InspectTabBase>(1);
                }
                t.inspectorTabsResolved.Add(InspectTabManager.GetSharedInstance(typeof(ITab_Pawn_Badge)));

                // add Badge component property to all humanlike pawns
                if (t.comps == null)
                {
                    t.comps = new List<CompProperties>(1);
                }
                t.comps.Add(new CompProperties_Badge());
            }
        }
    }
}
