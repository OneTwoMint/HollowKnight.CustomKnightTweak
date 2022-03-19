using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker.Actions;
using static Satchel.GameObjectUtils;
using static Satchel.FsmUtil;

namespace CustomKnight
{
    public class Shield : Skinable_Tk2d
    {
        public static string NAME = "Shield";
        public Shield() : base(Shield.NAME){}
        public override Material GetMaterial(){
            GameObject hc = HeroController.instance.gameObject;
            GameObject charmEffects = hc.FindGameObjectInChildren("Charm Effects");
            PlayMakerFSM spawnOrbitShield = charmEffects.LocateMyFSM("Spawn Orbit Shield");
            GameObject orbitShield = spawnOrbitShield.GetAction<SpawnObjectFromGlobalPool>("Spawn", 2).gameObject.Value;
            GameObject shield = orbitShield.FindGameObjectInChildren("Shield");
            var _shieldMat = shield.GetComponent<tk2dSprite>().GetCurrentSpriteDef().material;

            return _shieldMat;
        }

    }
}