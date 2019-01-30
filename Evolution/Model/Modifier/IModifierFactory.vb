Imports Evolution.ModifierAddress
Imports Evolution

Namespace Modifier

    Public Interface IModifierFactory
        Function NewModifier() As IModifier
        Function NewModifier(changeOperator As IModifier.ModifierOperator) As IModifier
        Function NewModifier(changeOperator As IModifier.ModifierOperator, target As IModifierAddress, firstArg As IModifierAddress, secondArg As IModifierAddress) As IModifier

    End Interface

End Namespace
