using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldShop : MonoBehaviour
{
    public int _gold;
    public int _dim;
    public void OnClick()
    {
        int dim = PlayerPrefs.GetInt("dim");
        if (dim>= _dim)
        {
            dim -= _dim;
            PlayerPrefs.SetInt("dim", dim);
            int gold= PlayerPrefs.GetInt("gold");
            gold += _gold;
            PlayerPrefs.SetInt("gold", gold);
        }
    }
}
