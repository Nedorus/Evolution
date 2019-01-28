Imports System.Xml.Serialization
Imports Evolution

Public Interface IModifierAddress
    Inherits IXmlSerializable


    Enum ReferenceTypeValue
        Undefined
        Absolute
        Direct
        Indirect
        Environment
        OtherCreature
    End Enum

    ReadOnly Property ReferenceType As ReferenceTypeValue
    Property ReferenceInteger As Integer
    Property ReferenceCreatureData As ICreatureDataDefinitions.CreatureData

    ''' <summary>
    ''' <para>
    ''' The following rules shall apply for the execution of SetValueByReferenceType
    ''' Override this in the derived classes appropriately
    ''' </para>
    ''' 
    ''' <para>
    ''' Undefined
    '''  do nothing
    ''' </para>
    ''' 
    ''' <para>
    ''' Absolute
    '''   Do nothing
    ''' </para>
    ''' 
    ''' <para>
    ''' Direct
    ''' write the value specified by CreatureData (for GeneCode use ReferenceInteger as Index)
    '''    Undefined -> do nothing
    '''    GeneCode -> use ReferenceInteger as index and set GeneCode there
    '''    Other -> set that value
    ''' </para>
    ''' 
    ''' <para>
    ''' Indirect
    ''' write to GenCode using an index depending On CreatureData
    '''    Undefined -> use 0 as index
    '''    GeneCode -> use value found in GeneCode at index ReferenceInteger as index
    '''    Other -> use that value as index
    ''' </para>
    ''' 
    ''' <para>
    ''' Environment (unfinished Def)
    ''' write to world depending On CreatureData
    '''    Undefined, XPosition, YPosition, GeneCode, GeneCounter  -> do nothing
    '''    Other -> write that value to the world
    ''' </para>
    ''' 
    ''' <para>
    ''' OtherCreature (unfinished Def)
    ''' write a value to another creature If that ceature Is Within a radius smaler than ReferenceInteger
    '''    Undefined -> do nothing
    '''    GeneCode -> returns 1 if otherCreature.geneCode.Equals(thisCreature.GeneCode) else 0
    '''    Other -> returns that value from OtherCreature
    ''' </para>
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <param name="newValue"></param>
    Sub SetValueByReferenceType(creature As Creature, newValue As Integer)

    ''' <summary>
    ''' <para>
    ''' The following rules shall apply for the execution of GetValueByReferenceType()
    ''' Override this in the derived classes appropriately
    ''' </para>
    '''
    ''' <para>
    ''' Undefined
    '''    return 0
    ''' </para>
    ''' 
    ''' <para> 
    ''' Absolute
    ''' returns the value given In ReferenceInteger
    '''    ignores CreatureData
    ''' </para>
    ''' 
    ''' <para> 
    ''' Direct
    ''' returns the value specified by CreatureData (for GeneCode use ReferenceInteger as Index)
    '''    Undefined -> return 0
    '''    GeneCode -> use ReferenceInteger as index
    '''    GeneCounter -> use that value and increase GeneCounter
    '''    Other -> use that value
    ''' </para>
    ''' 
    ''' <para>
    ''' Indirect
    ''' returns the GeneCode value using an index depending On CreatureData
    '''    Undefined -> use 0 as index
    '''    GeneCode -> use value found in GeneCode at index ReferenceInteger as index
    '''    Other -> use that value as index
    ''' </para>
    ''' 
    ''' <para>
    ''' Environment (unfinished Def)
    ''' returns the value stored In the world depending On CreatureData
    '''    Undefined, XPosition, YPosition -> return 0
    '''    GeneCode, GeneCounter -> return this creatures index/id
    '''    Other -> return that value from world
    ''' </para>
    ''' <para>
    ''' OtherCreature (unfinished Def)
    ''' returns a value Of another creature If that ceature Is With a radius smaler than ReferenceInteger
    '''    Undefined -> return 0
    '''    GeneCode -> returns 1 if otherCreature.geneCode.Equals(thisCreature.GeneCode) else 0
    '''    Other -> returns that value from OtherCreature
    ''' </para>
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <returns></returns>
    Function GetValueByReferenceType(ByRef creature As Creature) As Integer

End Interface
