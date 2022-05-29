using System;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace MysteryBow.Projectiles
{
    public class Placeholder : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.timeLeft = 0;
        }
    }
}

