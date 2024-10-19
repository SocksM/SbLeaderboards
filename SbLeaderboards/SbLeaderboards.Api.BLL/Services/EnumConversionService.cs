using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.BLL.Services
{
    public class EnumConversionService
    {
        static public ProfileType? ToProfileType(string input)
        {
			if (input == null) return ProfileType.Regular;

            switch (input.ToLower())
            {
                case null:
                case "":
                    return ProfileType.Regular;
                case "ironman":
                    return ProfileType.Ironman;
                case "bingo":
                    return ProfileType.Bingo;
                case "island":
                    return ProfileType.Stranded;
                case "unkown":
                default:
                    return null;
            }
        }

		static public ProfileCuteName? ToProfileCuteName(string input)
		{
			if (input == null) return null;

			switch (input.ToLower())
			{
				case "apple":
					return ProfileCuteName.Apple;
				case "banana":
					return ProfileCuteName.Banana;
				case "blueberry":
					return ProfileCuteName.Blueberry;
				case "cucumber":
					return ProfileCuteName.Cucumber;
				case "coconut":
					return ProfileCuteName.Coconut;
				case "grapes":
					return ProfileCuteName.Grapes;
				case "kiwi":
					return ProfileCuteName.Kiwi;
				case "lemon":
					return ProfileCuteName.Lemon;
				case "lime":
					return ProfileCuteName.Lime;
				case "mango":
					return ProfileCuteName.Mango;
				case "orange":
					return ProfileCuteName.Orange;
				case "papaya":
					return ProfileCuteName.Papaya;
				case "pineapple":
					return ProfileCuteName.Pineapple;
				case "peach":
					return ProfileCuteName.Peach;
				case "pear":
					return ProfileCuteName.Pear;
				case "pomegranate":
					return ProfileCuteName.Pomegranate;
				case "raspberry":
					return ProfileCuteName.Raspberry;
				case "strawberry":
					return ProfileCuteName.Strawberry;
				case "tomato":
					return ProfileCuteName.Tomato;
				case "watermelon":
					return ProfileCuteName.Watermelon;
				case "zucchini":
					return ProfileCuteName.Zucchini;
				case null:
				case "unkown":
				case "":
				default:
					return null;
			}
		}
	}
}