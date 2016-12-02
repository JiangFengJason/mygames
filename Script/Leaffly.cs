using UnityEngine;
using System.Collections;

public class Leaffly : MonoBehaviour {
    public GameObject leafef;
    private EffectController.Bullet effb;
    public EffectController effect;
    private int id;
	// Use this for initialization
	void Start () {
        GameObject Leafef = (GameObject)Instantiate(leafef, this.transform.position + new Vector3(0, 0, -1), this.transform.rotation);
        effb.dmg = 1;
        effb.speedup = 1;
        effb.dmgup = 2;
        effb.PlayerBullet = false;
        effb.Perfab = leafef;
        effb.bulletgo = Leafef;
        effect.BulletListOfEnermy.Add(effb);
        id = effect.GetBulletIdByGO(Leafef, effect.BulletListOfEnermy);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
