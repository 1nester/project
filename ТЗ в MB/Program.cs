// 1. Первое задание

using System;
using System.Collections.Generic;

namespace GeometryLib
{
    // Интерфейс для фигуры
    public interface IShape
    {
        double GetArea();  // Метод для вычисления площади
    }

    // Класс для круга
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);  // Площадь круга
        }
    }

    // Класс для треугольника
    public class Triangle : IShape
    {
        private double A { get; }
        private double B { get; }
        private double C { get; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;

            if (!IsValidTriangle())
            {
                throw new ArgumentException("Такого треугольника не существует.");
            }
        }

        public double GetArea()
        {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));  // Формула Герона
        }

        public bool IsRightTriangle()
        {
            double[] sides = { A, B, C };
            Array.Sort(sides);
            return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 0.00001;
        }

        private bool IsValidTriangle()
        {
            return A + B > C && A + C > B && B + C > A;
        }
    }

    // Класс для работы с фигурами через фабрику
    public static class ShapeFactory
    {
        // Метод для создания фигуры по типу и параметрам
        public static IShape CreateShape(string shapeType, params double[] parameters)
        {
            switch (shapeType.ToLower())
            {
                case "circle":
                    return new Circle(parameters[0]);
                case "triangle":
                    return new Triangle(parameters[0], parameters[1], parameters[2]);
                default:
                    throw new ArgumentException("Неизвестный тип фигуры");
            }
        }
    }

    // Класс для работы с фигурами, позволяющий динамическое использование
    public static class ShapeAreaCalculator
    {
        public static double GetArea(IShape shape)
        {
            return shape.GetArea();
        }

        // Является ли треугольник прямоугольным
        public static bool IsRightTriangle(IShape shape)
        {
            if (shape is Triangle triangle)
            {
                return triangle.IsRightTriangle();
            }

            throw new InvalidOperationException("Фигура не является треугольником.");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IShape circle = ShapeFactory.CreateShape("circle", 5);
            Console.WriteLine("Площадь круга: " + ShapeAreaCalculator.GetArea(circle));

            IShape triangle = ShapeFactory.CreateShape("triangle", 3, 4, 5);
            Console.WriteLine("Площадь треугольника: " + ShapeAreaCalculator.GetArea(triangle));

            bool isRightTriangle = ShapeAreaCalculator.IsRightTriangle(triangle);
            Console.WriteLine("Прямоугольный треугольник: " + isRightTriangle);
        }
    }
}


// 2. Второе задание
// Прошу прощения, по возможности пришлось написать решение 2-го задания тут:

// SELECT P.ProductName, C.CategoryName
// FROM Products P
// LEFT JOIN ProductCategories PC ON P.ProductID = PC.ProductID
// LEFT JOIN Categories C ON PC.CategoryID = C.CategoryID;
