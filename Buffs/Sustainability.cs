using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TheDrowChallenge.Buffs
{
    class Sustainability : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sustainability");
            Description.SetDefault("Prevents decay on the surface");
        }
    }
}
