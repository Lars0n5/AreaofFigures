namespace AreaOfFigures {
    /// <summary>
    /// Описывает базовый функицонал наследуемых классов
    /// </summary>
    public interface IShape {
        /// <summary>
        /// Вычисляет площадь фигуры
        /// </summary>
        /// <returns>Площадь фигуры</returns>
        double CalcArea ();
    }
    /// <summary>
    /// Описывает круг и предоставляет методы для работы с ним
    /// </summary>
    public class Circle : IShape { 
        /// <summary>
        /// Радиус круга. Должен быть больше нуля
        /// </summary>
        public double Radius {  get; }
        /// <summary>
        /// Создает экземпляр класса Круг с переданным радиусом
        /// </summary>
        /// <param name="radius">Радиус круга. Должен быть больше нуля</param>
        /// <exception cref="ArgumentException">Возникает при нулевом или отрицательном значении радиуса</exception>
        public Circle (double radius) {
            if (radius <= 0)
                throw new ArgumentException ("Радиус должен быть больше нуля.");
            Radius = radius;
        }
        /// <summary>
        /// Возвращает площадь круга по его радиусу
        /// </summary>
        /// <returns>Площадь круга</returns>
        public double CalcArea () {
            return Math.PI * Radius * Radius;
        }
    }
    /// <summary>
    /// Описывает треугольник и предоставляет методы для работы с ним
    /// </summary>
    public class Triangle : IShape {
        /// <summary>
        /// Длина стороны A треугольника. Должна быть больше нуля 
        /// </summary>
        public double SideA { get; }
        /// <summary>
        /// Длина стороны B треугольника. Должна быть больше нуля 
        /// </summary>
        public double SideB { get; }
        /// <summary>
        /// Длина стороны C треугольника. Должна быть больше нуля 
        /// </summary>
        public double SideC { get; }
        /// <summary>
        /// Создает экземпляр класса Треугольник с переданными сторонами
        /// </summary>
        /// <param name="sideA">Длина стороны A треугольника. Должна быть больше нуля</param>
        /// <param name="sideB">Длина стороны B треугольника. Должна быть больше нуля</param>
        /// <param name="sideC">Длина стороны C треугольника. Должна быть больше нуля</param>
        /// <exception cref="ArgumentException">Возникает, если любая из сторон меньше или равна нулю</exception>
        /// <exception cref="ArgumentException">Возникает, если треугольника с такими сторонами не может существовать</exception>
        public Triangle (double sideA, double sideB, double sideC) {
            if ((sideA <= 0) || (sideB <= 0) || (sideC <= 0))
                throw new ArgumentException("Стороны должны быть больше нуля.");
            if (!IsValidTriangle(sideA, sideB, sideC))
                throw new ArgumentException("Треугольника с такими сторонами не может существовать.");
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }
        private bool IsValidTriangle (double a, double b, double c) {
            return a + b > c && a + c > b && b + c > a;
        }
        /// <summary>
        /// Вычисляет площадь треугольника по его сторонам
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double CalcArea () {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным.
        /// </summary>
        /// <returns><c>true</c> - треугольник прямоугольный, <c>false</c> - треугольник не прямоугольный</returns>
        public bool IsRightTriangle () {
            double[] sides = {SideA, SideB, SideC};
            Array.Sort(sides);
            return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-10;
        }
    }
    /// <summary>
    /// Предоставляет метод для вычисления площади фигур, реализующих интерфейс <see cref="IShape"/>
    /// </summary>
    public static class ShapeCalcArea {
        /// <summary>
        /// Вычисляет площади фигуры, переданной в качестве параметра
        /// </summary>
        /// <param name="shape">
        /// Экзампляр фигуры, реализующей интерфейс <see cref="IShape"/>
        /// </param>
        /// <returns>Площадь фигуры</returns>
        public static double CalcShapeArea(IShape shape) {
            return shape.CalcArea();
        }
    }
}
