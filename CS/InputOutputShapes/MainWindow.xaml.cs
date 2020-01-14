using DevExpress.Diagram.Core;
using DevExpress.Xpf.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InputOutputShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeStencils();
            diagram.DocumentSource = @"..\..\DefaultDocument.xml";
            diagram.QueryConnectionPoints += Diagram_QueryConnectionPoints;
        }
        void InitializeStencils()
        {
            DiagramStencil myStencil = new DiagramStencil("CustomStencil", "Custom Stencil");
            FactoryItemTool myContainerTool = new FactoryItemTool("Decoder", () => "Decoder", d => CreateDecoderContianer());
            myStencil.RegisterTool(myContainerTool);

            diagram.Stencils = new DiagramStencilCollection(myStencil);
            diagram.SelectedStencils = new StencilCollection(myStencil.Id);
        }
        private void Diagram_QueryConnectionPoints(object sender, DiagramQueryConnectionPointsEventArgs e)
        {
            DiagramShape shape = e.HoveredItem as DiagramShape;
            if (shape != null)
            {
                if (string.Equals(shape.Tag, "input"))
                {
                    e.ItemConnectionBorderState = ConnectionElementState.Hidden;
                    if (e.ConnectorPointType == ConnectorPointType.Begin)
                        e.ItemConnectionPointStates.ToList().ForEach(cp => cp.State = ConnectionElementState.Disabled);
                }
                else if (string.Equals(shape.Tag, "output"))
                {
                    e.ItemConnectionBorderState = ConnectionElementState.Hidden;
                    if (e.ConnectorPointType == ConnectorPointType.End)
                        e.ItemConnectionPointStates.ToList().ForEach(cp => cp.State = ConnectionElementState.Disabled);
                }
            }
        }

        public DiagramContainer CreateDecoderContianer()
        {
            DiagramContainer decoderContainer = new DiagramContainer()
            {
                Header = "Decoder",
                ItemsCanSelect = false,
                ItemsCanMove = false,
                DragMode = ContainerDragMode.ByAnyPoint,
                ShowHeader = true,
                CanAttachConnectorBeginPoint = false,
                CanAttachConnectorEndPoint = false,
                Width = 120,
                Height = 230,
            };
            decoderContainer.Items.Add(CreateInputPointShape(new Point(0, 40)));
            decoderContainer.Items.Add(CreateLabelShape(new Point(12, 30), "input 1", Sides.Left));
            decoderContainer.Items.Add(CreateInputPointShape(new Point(0, 140)));
            decoderContainer.Items.Add(CreateLabelShape(new Point(12, 130), "input 2", Sides.Left));

            decoderContainer.Items.Add(CreateOutputPointShape(new Point(110, 20)));
            decoderContainer.Items.Add(CreateLabelShape(new Point(60, 10), "output 1", Sides.Right));

            decoderContainer.Items.Add(CreateOutputPointShape(new Point(110, 70)));
            decoderContainer.Items.Add(CreateLabelShape(new Point(60, 60), "output 2", Sides.Right));

            decoderContainer.Items.Add(CreateOutputPointShape(new Point(110, 120)));
            decoderContainer.Items.Add(CreateLabelShape(new Point(60, 110), "output 3", Sides.Right));

            decoderContainer.Items.Add(CreateOutputPointShape(new Point(110, 170)));
            decoderContainer.Items.Add(CreateLabelShape(new Point(60, 160), "output 4", Sides.Right));
            return decoderContainer;
        }

        DiagramShape CreateInputPointShape(Point position)
        {
            return new DiagramShape()
            {
                Tag = "input",
                Anchors = Sides.Left,
                Shape = BasicShapes.Ellipse,
                Position = position,
                MinWidth = 10,
                MinHeight = 10,
                ConnectionPoints = new DiagramPointCollection(new Point[] { new Point(0, 0.5) }),
                Background = Brushes.Black
            };
        }

        DiagramShape CreateOutputPointShape(Point position)
        {
            return new DiagramShape()
            {
                Tag = "output",
                Anchors = Sides.Right,
                Shape = BasicShapes.Ellipse,
                Position = position,
                MinWidth = 10,
                MinHeight = 10,
                ConnectionPoints = new DiagramPointCollection(new Point[] { new Point(1, 0.5) }),
                Background = Brushes.Green
            };
        }

        DiagramShape CreateLabelShape(Point position, string text, Sides anchors)
        {
            return new DiagramShape()
            {
                Content = text,
                Position = position,
                Anchors = anchors,
                StrokeThickness = 0,
                Foreground = Brushes.Black,
                Background = Brushes.Transparent,
                CanAttachConnectorBeginPoint = false,
                CanAttachConnectorEndPoint = false,
                Height = 30
            };
        }
    }
}
