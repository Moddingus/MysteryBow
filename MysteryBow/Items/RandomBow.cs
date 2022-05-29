using Terraria.ID;
using Terraria.ModLoader;
using MysteryBow.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;

namespace MysteryBow.Items
{
    public class RandomBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Random Bow"); 
			Tooltip.SetDefault("will almost always get you into more trouble than you started with...");
		}

		public override void SetDefaults() 
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.width = 12;
			item.height = 28;
			item.shoot = ModContent.ProjectileType<Placeholder>();
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.damage = 40;
			item.shootSpeed = 6.6f;
			item.noMelee = true;
			item.value = 1400;
			item.ranged = true;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(Main.rand.Next(0, Main.maxItems), Main.rand.Next(1, 10));
			recipe.AddIngredient(Main.rand.Next(0, Main.maxItems), Main.rand.Next(1, 10));
			recipe.AddIngredient(Main.rand.Next(0, Main.maxItems), Main.rand.Next(1, 10));
			recipe.AddIngredient(Main.rand.Next(0, Main.maxItems), Main.rand.Next(1, 10));
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			int randomP = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Main.rand.Next(0, Main.maxProjectiles), Main.rand.Next(1,400), knockBack, player.whoAmI);
			Main.projectile[randomP].friendly = true;
			Main.projectile[randomP].hostile = false;
			Main.projectile[randomP].timeLeft = 2000;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}