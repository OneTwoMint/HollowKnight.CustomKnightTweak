namespace CustomKnight
{
    internal class Sprint : Skinable_Tk2d
    {
        public static string NAME = "Sprint";
        public Sprint() : base(NAME) { }
        public override Material GetMaterial()
        {
            return HeroController.instance.gameObject.GetComponent<tk2dSpriteAnimator>().GetClipByName("Sprint").frames[0].spriteCollection.spriteDefinitions[0].material;
        }

    }
}