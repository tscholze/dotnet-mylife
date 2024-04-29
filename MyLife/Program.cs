// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using MyLife.Core;

Console.WriteLine("Hello, World!");

var json = Exporter.ExportLife();
File.WriteAllText("C:\\Users\\TobiasScholze\\Desktop\\life.json", json);