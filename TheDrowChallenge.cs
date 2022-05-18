using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace TheDrowChallenge {
	class TheDrowChallenge : Mod {
		public override void Load() {
			IL.Terraria.Main.UpdateTime += HookUndergroundBossSpawns;
		}

		private void HookUndergroundBossSpawns(ILContext il) {  // Remove the surface check from the boss spawns
			ILCursor c = new ILCursor(il);
			while (c.TryGotoNext(i => i.MatchLdsfld(typeof(Main), nameof(Main.player)))) {
				if (!c.Next.Next.Next.Next.Next.Next.Next.MatchLdsfld(typeof(Main), nameof(Main.worldSurface)))
					continue;
				c.RemoveRange(10);
			}
		}
	}
}
