// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using MyLife.Core;

Console.WriteLine("Hello, World!");

var json = Exporter.ExportLife();
System.Console.WriteLine(json);