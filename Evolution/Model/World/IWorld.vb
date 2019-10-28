Imports Evolution

Namespace World

    Public Interface IWorld

        Property XSize As Integer
        Property YSize As Integer
        Property Population As CreaturePopulation

        Function PickupResource(ByVal position As Position, ByVal resource As ResourceInfo)
        Sub DropResource(position As Position, resource As ResourceInfo)

    End Interface

End Namespace
