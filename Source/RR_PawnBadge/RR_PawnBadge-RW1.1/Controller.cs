using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RR_PawnBadge
{
    public class Controller : Verse.Mod
    {
        public static Settings Settings;

        public Controller(ModContentPack content) : base(content)
        {
            // provide settings
            Settings = GetSettings<Settings>();
        }

        public override string SettingsCategory() { return "PawnBadge"; }

        public override void DoSettingsWindowContents(Rect canvas) { Settings.DoWindowContents(canvas); }
    }
}
