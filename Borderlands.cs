using Terraria.ModLoader;

namespace Borderlands
{
	class Borderlands : Mod
	{
		public Borderlands()
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
