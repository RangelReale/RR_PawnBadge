using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RR_PawnBadge
{
    class ITab_Pawn_Badge : ITab
    {
        public ITab_Pawn_Badge()
        {
            this.size = new UnityEngine.Vector2(500f, 470f); ;
            this.labelKey = "TabBadge";
        }
        protected override void FillTab()
        {
            Widgets.Label(new Rect(0f, 0f, this.size.x, this.size.y), "Pawn badge text");
        }
    }
}
