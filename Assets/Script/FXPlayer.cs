using UnityEngine;
using System.Collections;

public class FXPlayer : MonoBehaviour
{
    [Header("FXData:  Prefab(in Project)--Position(in Scene)")]
    [Header("               DelayTime--DeleteTime--LinkType")]
    public FXData[] _fxdata;
   
    IEnumerator PlayFX(FXData _data)
    {
        yield return new WaitForSeconds(_data.fX_delay);
        if (_data.fX)
        {
            GameObject eff01 = (GameObject)Instantiate(_data.fX, _data.fX_position.position, _data.fX_position.rotation);

            if ((int)_data.fX_linktype == 2)
            {
                eff01.transform.parent = _data.fX_position.transform;
            }
            if ((int)_data.fX_linktype == 1)
            {
                eff01.AddComponent<FXLinkPos>();
                FXLinkPos _plinkpos = eff01.GetComponent<FXLinkPos>();
                _plinkpos.linkPos = _data.fX_position;
            }

            Destroy(eff01, _data.fX_delete);
        }
    }

    public void PlayIndexFX(int index)
    {
        if (index < _fxdata.Length)
        {
            StartCoroutine(PlayFX(_fxdata[index]));
        }
    }

    public void PlayAllFX()
    {
        int i = 0;

        for (i = 0; i < _fxdata.Length; i++)
        {
            StartCoroutine(PlayFX(_fxdata[i]));
        }
    }
}
