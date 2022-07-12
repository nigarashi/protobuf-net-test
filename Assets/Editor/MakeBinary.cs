using System.IO;

using ProtoBuf;
using UnityEditor;
using UnityEngine;

public class MakeBinary
{
    [MenuItem("Binary/Make")]
    public static void Make()
    {
        var person = new Person {
            Id = 12345, Name = "Fred",
            Address = new Address {
                Line1 = "Flat 1",
                Line2 = "The Meadows"
            }
        };
        using (var file = File.Create($"{Application.dataPath}/Resources/person.bytes"))
        {
            Serializer.Serialize(file, person);
        }
        
        AssetDatabase.Refresh();
    }
}
