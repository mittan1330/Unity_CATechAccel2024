using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RunGame.Charactor;

namespace RunGame.UI
{
    public class HPSlider : MonoBehaviour
    {
        Slider healthBar;

        // Start is called before the first frame update
        void Start()
        {
            healthBar = this.gameObject.GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {
            GameManager.GameTime += Time.deltaTime;
            Player.hp -= Time.deltaTime;

            healthBar.value = Player.hp;
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}