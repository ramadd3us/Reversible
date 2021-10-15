using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReturn : MonoBehaviour
{
    [SerializeField] private GameObject _person;
    [SerializeField] private int reverseLimit = 10;
    private List<List<Vector3>> _objectPosition = new List<List<Vector3>>();
    
    //private ArrayList _personPositions;
    private List<GameObject> _dublicates;
    private bool _isReversing = false;

    private int _reverseCounter = 0;
    void Start()
    {
        //_objectPosition = 
        for (int i = 0; i < reverseLimit; i++)
        {
            _objectPosition.Add(new List<Vector3>());
        }
        //_personPositions = new ArrayList();
        
        Debug.Log(_objectPosition[0]);
        _dublicates = new List<GameObject>();
        Debug.Log(_reverseCounter);
    }
    
    void Update()
    {
        if (_reverseCounter < reverseLimit)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _dublicates.Add(Instantiate(_person));
                if (_reverseCounter % 2 == 0)//четное
                {
                    if (_reverseCounter > 0)
                    {
                        for (int i = _reverseCounter; i >= 0; i -= 2)
                        {
                            var temp = new Color(1f, 0f, 0f,
                                _dublicates[i].GetComponent<Renderer>().material.color.a - 0.1f);
                            
                            _dublicates[i].GetComponent<Renderer>().material.SetColor("_Color", temp);

                        }
                    }
                    else
                    {
                        var temp = new Color(1f, 0f, 0f, 0.8f);
                        _dublicates[_reverseCounter].GetComponent<Renderer>().material.SetColor("_Color", temp);
                    }

                    _isReversing = true;
                    _person.GetComponent<Renderer>().material.color = Color.blue;
                }
                else //Нечетное
                {
                    if (_reverseCounter > 1)
                    {
                        for (int i = _reverseCounter; i > 0; i -= 2)
                        {
                            var temp = new Color(0f, 0f, 1f,
                                _dublicates[i].GetComponent<Renderer>().material.color.a - 0.1f);
                            
                            _dublicates[i].GetComponent<Renderer>().material.SetColor("_Color", temp);

                        }
                    }
                    else
                    {
                        var temp = new Color(0f, 0f, 1f, 0.8f);
                        _dublicates[_reverseCounter].GetComponent<Renderer>().material.SetColor("_Color", temp);
                    }

                    _isReversing = false;
                    _person.GetComponent<Renderer>().material.color = Color.red;
                }

                _reverseCounter++;
                GetComponent<TimeCounter>().ReverseTime(_reverseCounter);
            }
        }
    }
    
    void FixedUpdate()
    {
        if(_reverseCounter < reverseLimit)
            _objectPosition[_reverseCounter].Add (_person.transform.position);
        Debug.Log(_reverseCounter);
        if(!_isReversing)//Нечетное
        {
            //здесь for для 
            
            
            if (_reverseCounter > 0)
            {
                if(_objectPosition[_reverseCounter - 1].Count - 1 > -1)
                {
                    for (int i = 0; i >= _reverseCounter - 1; i ++)
                    {
                        _dublicates[i].transform.position = _objectPosition[i][_objectPosition[i].Count - 1];
                        
                    }
                    _objectPosition[_reverseCounter - 1].RemoveAt(_objectPosition[_reverseCounter - 1].Count - 1);
                }
            }
        }
        else //Четное
        {
            //здесь for для 
            
            if (_objectPosition[_reverseCounter - 1].Count - 1 > -1)
            {
                for (int i = _reverseCounter - 1; i > 0 ; i --)
                {
                    _dublicates[i].transform.position = _objectPosition[i][_objectPosition[i].Count - 1];
                }
                _objectPosition[_reverseCounter - 1].RemoveAt(_objectPosition[_reverseCounter - 1].Count - 1);
            }
        }
    }
}
