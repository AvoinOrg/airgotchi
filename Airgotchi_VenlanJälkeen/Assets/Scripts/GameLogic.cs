using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLogic : MonoBehaviour
{
  [SerializeField] Sprite egg;
  [SerializeField] Sprite egg_hatched;
  [SerializeField] Sprite happy;
  [SerializeField] Sprite sad;
  [SerializeField] Sprite angry;

  [SerializeField] Image  target;

  int status = 0;


  void Start()
  {
  }

  void Update()
  {
  }

  public void Tap()
  {
    if      (status == 0) target.sprite = egg_hatched;
    else if (status == 1) target.sprite = happy;

    ++status;
  }
}
