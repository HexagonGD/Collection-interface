using System.Collections.Generic;
using UnityEngine;

public class PetCollection
{
    private List<PetInfo> _petInfo;

    public int Count => _petInfo.Count;

    public PetCollection()
    {
        _petInfo = new List<PetInfo>();
        _petInfo.AddRange(Resources.LoadAll<PetInfo>("PetInfos"));
    }

    public PetInfo GetPetInfo(int index)
    {
        return _petInfo[index];
    }

    public bool TryGetPetInfo(int index, out PetInfo info)
    {
        bool result;
        info = default;

        if(index < 0 || index >= _petInfo.Count)
        {
            result = false;
        }
        else
        {
            info = GetPetInfo(index);
            result = true;
        }

        return result;
    }
}