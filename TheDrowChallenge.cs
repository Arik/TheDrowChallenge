using Terraria.ModLoader;

namespace TheDrowChallenge
{
	class TheDrowChallenge : Mod
	{
		public TheDrowChallenge()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
