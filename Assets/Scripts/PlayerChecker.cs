using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerChecker : MonoBehaviour
{
  public static int score;
  public Text scoreText;
  int factor;
  private void Awake()
  {
    factor = 1;
    score = 0;
  }
  private void Update()
  {
    scoreText.text = score.ToString();
  }
     private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.TryGetComponent(out BumpDestroyChecker bumpDestroyChecker))
    {
      GameObject parent = bumpDestroyChecker.transform.root.gameObject;
      string bumpTag = parent.tag;
      BumpAction(bumpTag);
      Destroy(parent);
    }
  }

  public void BumpAction(string bumpTag)
  {
    switch(bumpTag)
    {
      case "SmallBump":
        score += 1 * factor;
        factor = 1;
        break;
      case "BigBump":
        score += 3 * factor;
        factor = 1;
        break;
      case "DoubleBooster":
        factor *= 2;
        break;
     
      }
  }
}
