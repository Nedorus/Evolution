Imports Evolution

Namespace World

    Public Class World
        Implements IWorld

        Private _xSize As Integer
        Private _ySize As Integer
        Private _population As CreaturePopulation

        Public Property XSize As Integer Implements IWorld.XSize
            Get
                Return _xSize
            End Get
            Set(value As Integer)
                _xSize = value
            End Set
        End Property

        Public Property YSize As Integer Implements IWorld.YSize
            Get
                Return _ySize
            End Get
            Set(value As Integer)
                _ySize = value
            End Set
        End Property

        Public Property Population As CreaturePopulation Implements IWorld.Population
            Get
                Return _population
            End Get
            Set(value As CreaturePopulation)
                _population = value
            End Set
        End Property

        Public Function PickupResource(position As Position, resource As ResourceInfo) As Object Implements IWorld.PickupResource
            Throw New NotImplementedException()
        End Function

        Public Sub DropResource(position As Position, resource As ResourceInfo) Implements IWorld.DropResource

        End Sub
    End Class

End Namespace
