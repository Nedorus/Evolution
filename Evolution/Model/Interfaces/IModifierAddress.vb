Imports System.Xml.Serialization

Public Interface IModifierAddress
    Inherits IXmlSerializable


    Enum ReferenceTypeValue
        Undefined
        Absolute
        Relative
        Indirect
        Environment
        OtherCreature
    End Enum

    ReadOnly Property ReferenceType As ReferenceTypeValue
    Property ReferenceInteger As Integer
    Property ReferenceCreatureData As ICreatureDataDefinitions.CreatureData
    Function GetValueByReferenceType(ByRef creature As Creature) As Integer

End Interface
