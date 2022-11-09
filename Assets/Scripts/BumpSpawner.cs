using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _bumps;
    [SerializeField] private int fieldDimension;
    public float _spawnTimePeriod;
    public float _timeToDestroy;
    private float timeLeft;
    private Vector3 bumpSpawnPosition;
    private bool[,] isFree;
    public struct bumpsOnField 
    {
        public int X, Z ;
        public float timePassed;
        public GameObject bump;
    }


    public List<bumpsOnField>  _bumpsOnField = new List<bumpsOnField>();
    private void Start()
    { 
        isFree = new bool[fieldDimension, fieldDimension];
        for(int i = 0; i < fieldDimension; i++)
            for(int j = 0; j < fieldDimension; j++)
                isFree[i, j] = true;
        timeLeft = 0;
    }
    private void Update()
    {
        if(timeLeft <= 0)
        {
            CreateBump(SelectBump());
            timeLeft = _spawnTimePeriod;
        }
        else
            timeLeft -= Time.deltaTime;

        for(int i = 0; i < _bumpsOnField.Count; i++)
        {
            var tmp = _bumpsOnField[i];
            tmp.timePassed -= Time.deltaTime;
            _bumpsOnField[i] = tmp;
        }
        if(_bumpsOnField[0].timePassed <= 0)
            DestroyBump();
    }

    private int SelectBump()
    {
        int random = Random.Range(0, 100);
        if(random <= 50)
            return 0;
        if(random > 60 && random <= 90)
            return 1;
        if(random > 90)
            return 2;
        return 0;
    }
    private void CreateBump(int num)
    {        
        int X, Z;
        do
        {
            X = Random.Range(0, fieldDimension);
            Z = Random.Range(0, fieldDimension); 
        }
        while (isFree[X,Z] == false);
        isFree[X,Z] = false;
        bumpSpawnPosition = new Vector3(X, 0.5f, Z);
        bumpsOnField tmp;
        
        tmp.bump = Instantiate(_bumps[num], bumpSpawnPosition, Quaternion.identity, null);
        tmp.bump.name = "Bump";
        Debug.Log(tmp.bump.name);
        tmp.X = X;
        tmp.Z = Z;
        tmp.timePassed = _timeToDestroy;
        _bumpsOnField.Add(tmp);
    }
    private void DestroyBump()
    {
        isFree[_bumpsOnField[0].X, _bumpsOnField[0].Z] = true;
        _bumpsOnField.RemoveAt(0);
        GameObject destroying = _bumpsOnField[0].bump.transform.gameObject;
        Destroy(destroying);
    }

}
