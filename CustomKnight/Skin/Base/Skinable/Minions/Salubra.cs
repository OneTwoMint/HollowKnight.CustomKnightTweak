﻿using HutongGames.PlayMaker;
using Satchel.Futils;

namespace CustomKnight
{
    internal class Salubra : Skinable
    {
        public static string NAME = "Salubra";
        public Salubra() : base(NAME) { }

        public override void ApplyTexture(Texture2D tex)
        {
            var go = HeroController.instance.gameObject.FindGameObjectInChildren("Blessing Ghost");
            if (go == null) { return; }
            var fsm = go.LocateMyFSM("Blessing Control");
            var finalGo = fsm.GetVariable<FsmGameObject>("Blessing_Ghost")?.Value;
            if (finalGo == null) { return; }
            var behaviour = finalGo.GetAddComponent<SpriteRendererMaterialPropertyBlock>();
            if (tex != null)
            {
                MaterialPropertyBlock block = new MaterialPropertyBlock();
#pragma warning disable CS0618 // Type or member is obsolete
                block.AddTexture("_MainTex", tex);
#pragma warning restore CS0618 // Type or member is obsolete
                behaviour.mpb = block;
                behaviour.enabled = true;
            }
            else
            {
                behaviour.enabled = false;
            }
        }

        public override void SaveDefaultTexture()
        {
            var go = HeroController.instance.gameObject.FindGameObjectInChildren("Blessing Ghost");
            if (go == null) { return; }
            var fsm = go.LocateMyFSM("Blessing Control");
            var finalGo = fsm.GetVariable<FsmGameObject>("Blessing_Ghost")?.Value;
            if (finalGo == null) { return; }
            var sr = finalGo.GetComponent<SpriteRenderer>();
            if (sr == null) { return; }
            ckTex.defaultTex = sr.sprite.texture;
        }
    }
}
