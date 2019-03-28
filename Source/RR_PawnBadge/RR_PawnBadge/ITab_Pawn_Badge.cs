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
        private bool[] badgePainting = { false, false };

        public ITab_Pawn_Badge()
        {
            this.size = new UnityEngine.Vector2(500f, 470f); ;
            this.labelKey = "TabBadge";
        }

        private Pawn SelPawnForBadgeInfo
        {
            get
            {
                if (base.SelPawn != null)
                {
                    return base.SelPawn;
                }
                Corpse corpse = base.SelThing as Corpse;
                if (corpse != null)
                {
                    return corpse.InnerPawn;
                }
                throw new InvalidOperationException("Badge tab on non-pawn non-corpse " + base.SelThing);
            }
        }

        protected override void FillTab()
        {
            CompBadge cb = SelPawnForBadgeInfo.GetComp<CompBadge>();
            if (cb == null) return;

            Rect rect = new Rect(0f, 0f, this.size.x, this.size.y);

            Rect[] badgeRects = new Rect[] {
                new Rect(rect.x, rect.y, rect.width, rect.height / 2),
                new Rect(rect.x, (rect.height / 2) + 1, rect.width, rect.height / 2),
            };

            GUI.BeginGroup(rect);
            Text.Font = GameFont.Small;

            GUI.color = new Color(1f, 1f, 1f, 0.5f);
            Widgets.DrawLineHorizontal(badgeRects[0].x, badgeRects[0].yMax, badgeRects[0].width);
            GUI.color = Color.white;

            for (int i = 0; i < 2; i++)
            {
                // Widgets.Label(new Rect(0f, 0f, this.size.x, this.size.y), "Pawn badge text");

                float x = badgeRects[i].x;
                float y = badgeRects[i].y + 20f;
                List<BadgeDef> defs = new List<BadgeDef>(DefDatabase<BadgeDef>.AllDefsListForReading);
                defs.Insert(0, new BadgeDef("", Mod.GreyTex));
                foreach (BadgeDef def in defs)
                {
                    Rect brect = new Rect(x, y, 40f, 30f);
                    Widgets.DrawHighlightIfMouseover(brect);
                    GUI.DrawTexture(brect, def.Symbol, ScaleMode.ScaleToFit);
                    Widgets.DraggableResult draggableResult = Widgets.ButtonInvisibleDraggable(brect, false);
                    if (draggableResult == Widgets.DraggableResult.Dragged)
                    {
                        badgePainting[i] = true;
                    }
                    if ((badgePainting[i] && Mouse.IsOver(brect) && def.defName != cb.badges[i]) || AnyPressed(draggableResult))
                    {
                        cb.badges[i] = def.defName;
                        SoundDefOf.Tick_High.PlayOneShotOnCamera(null);
                    }
                    if (cb.badges[i] == def.defName)
                    {
                        Widgets.DrawBox(brect, 3);
                    }
                    TooltipHandler.TipRegion(brect, () => def.description, 3882382 + (int)y * 17);

                    x += 40f;
                }
                if (!Input.GetMouseButton(0))
                {
                    badgePainting[i] = false;
                }
            }

            GUI.EndGroup();
        }

        private static bool AnyPressed(Widgets.DraggableResult result)
        {
            return result == Widgets.DraggableResult.Pressed || result == Widgets.DraggableResult.DraggedThenPressed;
        }

    }
}
