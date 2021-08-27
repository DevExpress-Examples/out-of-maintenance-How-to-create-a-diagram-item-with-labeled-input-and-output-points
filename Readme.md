<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/233870538/19.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T852192)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to create a diagram item with labeled input and output points

This example demonstrates how to add text to connection points and make them always visible in WPF DiagramControl:
![0](https://raw.githubusercontent.com/DevExpress-Examples/How-to-create-a-diagram-item-with-labeled-input-and-output-points/19.2.4%2B/item_image.png)

The main idea is to use the [DiagramContainer](https://documentation.devexpress.com/WPF/117205/Controls-and-Libraries/Diagram-Control/Diagram-Items/Containers) element to combine several shapes that will be used as input and output points. 
To prevent attaching connectors to inappropriate points, it's necessary to handle the [QueryConnectionPoints](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Diagram.DiagramControl.QueryConnectionPoints.event) event.
