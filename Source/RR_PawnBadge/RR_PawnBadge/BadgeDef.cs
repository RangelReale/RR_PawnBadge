using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RR_PawnBadge
{
    public class BadgeDef : Def
    {
        private Texture2D symbolTex;
        public string icon;

        public BadgeDef() : base()
        {

        }

        public BadgeDef(string defName, Texture2D symbolTex) : base()
        {
            this.defName = defName;
            this.description = "";
            this.symbolTex = symbolTex;
        }

        public Texture2D Symbol
        {
            get
            {
                if (this.symbolTex == null)
                {
                    this.symbolTex = ContentFinder<Texture2D>.Get(this.icon, true);
                }
                return this.symbolTex;
            }
        }
    }
}
