Imports System.Xml.Serialization

Public Interface IModifierAddress
    Inherits IXmlSerializable


    Enum ReferenceTypeValue
        Undefined
        Absolute
        Relative
        Indirect
    End Enum

    Property ReferenceType As ReferenceTypeValue
    Property ReferenceInteger As Integer
    Property ReferenceString As ICreatureDataDefinitions.CreatureData

End Interface
