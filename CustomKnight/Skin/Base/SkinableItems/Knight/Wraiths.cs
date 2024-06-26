namespace CustomKnight
{
    internal class Wraiths : Skinable_noCache
    {
        public static string NAME = "Wraiths";
        public Wraiths() : base(NAME) { }

        public static Shader backup;
        public override Material GetMaterial()
        {
            Material Wraiths = null;
            foreach (Transform child in HeroController.instance.gameObject.transform)
            {
                if (child.name == "Spells")
                {
                    foreach (Transform spellsChild in child)
                    {
                        if (spellsChild.name == "Scr Heads" || spellsChild.name == "Scr Base")
                        {
                            Wraiths = spellsChild.gameObject.GetComponent<tk2dSprite>().GetCurrentSpriteDef().material;
                            var skin = SkinManager.GetCurrentSkin() as ISupportsConfig;
                            if (backup == null)
                            {
                                backup = Wraiths.shader;
                            }
                            if (skin != null && skin.GetConfig().wraithsFilter)
                            {
                                Wraiths.shader = Shader.Find("Sprites/Default-ColorFlash") ?? backup;
                            }
                            else
                            {
                                Wraiths.shader = backup;
                            }
                        }
                    }
                }
            }
            return Wraiths;
        }

    }
}