using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace RR_PawnBadge
{
    public class ITab_Pawn_Badge : ITab
    {
        private bool badgePainting;

        public ITab_Pawn_Badge()
        {
            this.size = new UnityEngine.Vector2(500f, 470f); ;
            this.labelKey = "TabBadge";
        }
        protected override void FillTab()
        {
            if (base.SelPawn == null) return;
            CompBadge cb = base.SelPawn.GetComp<CompBadge>();
            if (cb == null) return;

            Widgets.Label(new Rect(0f, 0f, this.size.x, this.size.y), "Pawn badge text");

            float x = 0;
            float y = 20f;
            foreach (BadgeDef def in DefDatabase<BadgeDef>.AllDefsListForReading)
            {
                Rect brect = new Rect(x, y, 40f, 30f);
                Widgets.DrawHighlightIfMouseover(brect);
                GUI.DrawTexture(brect, def.Symbol);
                Widgets.DraggableResult draggableResult = Widgets.ButtonInvisibleDraggable(brect, false);
                if (draggableResult == Widgets.DraggableResult.Dragged)
                {
                    badgePainting = true;
                }
                if ((badgePainting && Mouse.IsOver(brect) && def.defName != cb.badgeA) || AnyPressed(draggableResult))
                {
                    cb.badgeA = def.defName;
                    SoundDefOf.Tick_High.PlayOneShotOnCamera(null);
                }
                if (cb.badgeA == def.defName)
                {
                    Widgets.DrawBox(brect, 3);
                }
                TooltipHandler.TipRegion(brect, () => def.description, 3882382 + (int)y * 17);

                x += 40f;
            }
            if (!Input.GetMouseButton(0))
            {
                badgePainting = false;
            }
        }

        private static bool AnyPressed(Widgets.DraggableResult result)
        {
            return result == Widgets.DraggableResult.Pressed || result == Widgets.DraggableResult.DraggedThenPressed;
        }

    }
}
