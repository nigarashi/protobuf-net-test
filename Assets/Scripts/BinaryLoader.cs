using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ProtoBuf;

public class BinaryLoader : MonoBehaviour
{
    Person newPerson;

    void Start()
    {
        var file = Resources.Load<TextAsset>("person");
        using (var stream = new MemoryStream(file.bytes))
        {
            newPerson = Serializer.Deserialize<Person>(stream);
        }
    }

    private void OnGUI()
    {
        GUILayout.TextField($"name: {newPerson.Name} id:{newPerson.Id} adress:{newPerson.Address}");
    }
}
