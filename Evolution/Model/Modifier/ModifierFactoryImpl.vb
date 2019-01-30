Imports Evolution
Imports Evolution.ModifierAddress
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Namespace Modifier

    Public Class ModifierFactoryImpl
        Implements IModifierFactory

        Public Function NewModifier() As IModifier Implements IModifierFactory.NewModifier
            Dim modifier As IModifier

            modifier = New ModifierUndefined()
            modifier.Target = New ModifierAddressUndefined()
            modifier.FirstArg = New ModifierAddressUndefined()
            modifier.SecondArg = New ModifierAddressUndefined()

            Return modifier

        End Function

        Public Function NewModifier(changeOperator As IModifier.ModifierOperator) As IModifier Implements IModifierFactory.NewModifier
            Dim modifier As IModifier

            Select Case changeOperator
                Case IModifier.ModifierOperator.Add
                    modifier = New ModifierAdd()
                Case IModifier.ModifierOperator.Subtract
                    modifier = New ModiefierSubtract()
                Case IModifier.ModifierOperator.Undefined
                    modifier = New ModifierUndefined()
                Case Else
                    modifier = New ModifierUndefined()
            End Select
            modifier.Target = New ModifierAddressUndefined()
            modifier.FirstArg = New ModifierAddressUndefined()
            modifier.SecondArg = New ModifierAddressUndefined()

            Return modifier

        End Function

        Public Function NewModifier(changeOperator As IModifier.ModifierOperator, target As IModifierAddress, firstArg As IModifierAddress, secondArg As IModifierAddress) As IModifier Implements IModifierFactory.NewModifier
            Dim modifier As IModifier = NewModifier(changeOperator)
            modifier.Target = target
            modifier.FirstArg = firstArg
            modifier.SecondArg = secondArg
            Return modifier
        End Function

        Public Function XmlDeserializeModifier(ByRef reader As XMLReader) As IModifier
            Dim modifier As IModifier
            Dim changeOperator As IModifier.ModifierOperator
            If Not reader.IsEmptyElement Then
                changeOperator = DirectCast([Enum].Parse(GetType(IModifier.ModifierOperator), reader.ReadElementContentAsString), IModifier.ModifierOperator)
            Else
                changeOperator = IModifier.ModifierOperator.Undefined
                reader.ReadElementContentAsString()
            End If
            modifier = Me.NewModifier(changeOperator)
            Dim modifierAddressFactory As IModifierAddressFactory = New ModifierAddressFactoryImpl()

            If Not reader.IsEmptyElement Then
                reader.ReadStartElement()
                reader.MoveToContent()
                modifier.Target = modifierAddressFactory.XmLDeserializeModifierAddress(reader)
            Else
                modifier.Target = modifierAddressFactory.NewModifierAddress()
            End If
            reader.ReadEndElement()

            If Not reader.IsEmptyElement Then
                reader.ReadStartElement()
                reader.MoveToContent()
                modifier.FirstArg = modifierAddressFactory.XmLDeserializeModifierAddress(reader)
            Else
                modifier.FirstArg = modifierAddressFactory.NewModifierAddress()
            End If
            reader.ReadEndElement()

            If Not reader.IsEmptyElement Then
                reader.ReadStartElement()
                reader.MoveToContent()
                modifier.SecondArg = modifierAddressFactory.XmLDeserializeModifierAddress(reader)
            Else
                modifier.SecondArg = modifierAddressFactory.NewModifierAddress()
            End If
            reader.ReadEndElement()




            Return modifier
        End Function

    End Class

End Namespace
