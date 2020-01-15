Imports DevExpress.Diagram.Core
Imports DevExpress.Xpf.Diagram
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace InputOutputShapes
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()

			InitializeStencils()
			diagram.DocumentSource = "..\..\DefaultDocument.xml"
			AddHandler diagram.QueryConnectionPoints, AddressOf Diagram_QueryConnectionPoints
		End Sub
		Private Sub InitializeStencils()
			Dim myStencil As New DiagramStencil("CustomStencil", "Custom Stencil")
			Dim myContainerTool As New FactoryItemTool("Decoder", Function() "Decoder", Function(d) CreateDecoderContianer())
			myStencil.RegisterTool(myContainerTool)

			diagram.Stencils = New DiagramStencilCollection(myStencil)
			diagram.SelectedStencils = New StencilCollection(myStencil.Id)
		End Sub
		Private Sub Diagram_QueryConnectionPoints(ByVal sender As Object, ByVal e As DiagramQueryConnectionPointsEventArgs)
			Dim shape As DiagramShape = TryCast(e.HoveredItem, DiagramShape)
			If shape IsNot Nothing Then
				If String.Equals(shape.Tag, "input") Then
					e.ItemConnectionBorderState = ConnectionElementState.Hidden
					If e.ConnectorPointType = ConnectorPointType.Begin Then
						e.ItemConnectionPointStates.ToList().ForEach(Sub(cp) cp.State = ConnectionElementState.Disabled)
					End If
				ElseIf String.Equals(shape.Tag, "output") Then
					e.ItemConnectionBorderState = ConnectionElementState.Hidden
					If e.ConnectorPointType = ConnectorPointType.End Then
						e.ItemConnectionPointStates.ToList().ForEach(Sub(cp) cp.State = ConnectionElementState.Disabled)
					End If
				End If
			End If
		End Sub

		Public Function CreateDecoderContianer() As DiagramContainer
			Dim decoderContainer As New DiagramContainer() With {
				.Header = "Decoder",
				.ItemsCanSelect = False,
				.ItemsCanMove = False,
				.DragMode = ContainerDragMode.ByAnyPoint,
				.ShowHeader = True,
				.CanAttachConnectorBeginPoint = False,
				.CanAttachConnectorEndPoint = False,
				.Width = 120,
				.Height = 230
			}
			decoderContainer.Items.Add(CreateInputPointShape(New Point(0, 40)))
			decoderContainer.Items.Add(CreateLabelShape(New Point(12, 30), "input 1", Sides.Left))
			decoderContainer.Items.Add(CreateInputPointShape(New Point(0, 140)))
			decoderContainer.Items.Add(CreateLabelShape(New Point(12, 130), "input 2", Sides.Left))

			decoderContainer.Items.Add(CreateOutputPointShape(New Point(110, 20)))
			decoderContainer.Items.Add(CreateLabelShape(New Point(60, 10), "output 1", Sides.Right))

			decoderContainer.Items.Add(CreateOutputPointShape(New Point(110, 70)))
			decoderContainer.Items.Add(CreateLabelShape(New Point(60, 60), "output 2", Sides.Right))

			decoderContainer.Items.Add(CreateOutputPointShape(New Point(110, 120)))
			decoderContainer.Items.Add(CreateLabelShape(New Point(60, 110), "output 3", Sides.Right))

			decoderContainer.Items.Add(CreateOutputPointShape(New Point(110, 170)))
			decoderContainer.Items.Add(CreateLabelShape(New Point(60, 160), "output 4", Sides.Right))
			Return decoderContainer
		End Function

		Private Function CreateInputPointShape(ByVal position As Point) As DiagramShape
			Return New DiagramShape() With {
				.Tag = "input",
				.Anchors = Sides.Left,
				.Shape = BasicShapes.Ellipse,
				.Position = position,
				.MinWidth = 10,
				.MinHeight = 10,
				.ConnectionPoints = New DiagramPointCollection(New Point() { New Point(0, 0.5) }),
				.Background = Brushes.Black
			}
		End Function

		Private Function CreateOutputPointShape(ByVal position As Point) As DiagramShape
			Return New DiagramShape() With {
				.Tag = "output",
				.Anchors = Sides.Right,
				.Shape = BasicShapes.Ellipse,
				.Position = position,
				.MinWidth = 10,
				.MinHeight = 10,
				.ConnectionPoints = New DiagramPointCollection(New Point() { New Point(1, 0.5) }),
				.Background = Brushes.Green
			}
		End Function

		Private Function CreateLabelShape(ByVal position As Point, ByVal text As String, ByVal anchors As Sides) As DiagramShape
			Return New DiagramShape() With {
				.Content = text,
				.Position = position,
				.Anchors = anchors,
				.StrokeThickness = 0,
				.Foreground = Brushes.Black,
				.Background = Brushes.Transparent,
				.CanAttachConnectorBeginPoint = False,
				.CanAttachConnectorEndPoint = False,
				.Height = 30
			}
		End Function
	End Class
End Namespace
