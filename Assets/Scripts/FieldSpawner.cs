using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
   [SerializeField] public int _fieldDimension;
   [SerializeField] private Floor _floor;
   [SerializeField] private Field _field;
 
  

    private void Awake()
    {
        BuildField();
        GameObject tmp1 = GameObject.Find("BumpSpawner");
        GameObject tmp2 = GameObject.Find("Player");
        tmp1.GetComponent<BumpSpawner>().enabled = true;
        tmp2.GetComponent<PlayerController>().enabled = true;
    }



     private void BuildField()
     {
          Vector3 fieldSpawnPosition = _field.transform.position;
          Vector3 playerSpawnPosition = fieldSpawnPosition;
          playerSpawnPosition.z += _fieldDimension / 2;
          playerSpawnPosition.x -= 1;

          Floor floor = Instantiate(_floor, transform);
          floor.transform.localScale = new Vector3(_fieldDimension + 4, 1, _fieldDimension + 4);
          floor.transform.position = new Vector3(fieldSpawnPosition.x + _fieldDimension / 2, 0, fieldSpawnPosition.z + _fieldDimension / 2);
     }


}
 