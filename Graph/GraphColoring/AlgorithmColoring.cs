using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib.GraphColoring
{
    /// <summary>
    /// Абстрактный класс для наследования и переопределения
    /// алгоритма раскраски графа.
    /// </summary>
    public abstract class AlgorithmColoring
    {
        public abstract List<List<Vertex>> Coloring(Graph graph);
    }
}
