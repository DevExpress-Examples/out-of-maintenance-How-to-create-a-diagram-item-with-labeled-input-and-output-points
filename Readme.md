# How to create a diagram item with labeled input and output points

This example demonstrates how to add text to diagram connection points and make them always visible:
![0](https://raw.githubusercontent.com/DevExpress-Examples/How-to-create-a-diagram-item-with-labeled-input-and-output-points/19.2.4%2B/item_image.png)

The main idea is to use the [DiagramContainer](https://documentation.devexpress.com/WPF/117205/Controls-and-Libraries/Diagram-Control/Diagram-Items/Containers) element to combine several shapes that will be used as input and output points. 
To prevent attaching connectors to inappropriate points, it's necessary to handle the [QueryConnectionPoints](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Diagram.DiagramControl.QueryConnectionPoints.event) event.
