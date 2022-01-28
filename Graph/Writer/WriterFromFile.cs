namespace GraphLib.Writer
{
    public class WriterFromFile : IWriter
    {
        private string path;

        public WriterFromFile(string path)
        {
            this.path = path;
        }

        public void SetPathWriter(string path)
        {
            this.path = path;
        }

        public void Write(Graph graph)
        {
            using(var stream = new System.IO.StreamWriter(path))
            {
                var strGraph = PrinterGraph.AdjancyMatrix(graph, ConvertGraph.GetAdjancyMatrix(graph));
                stream.Write(strGraph);
            }
        }
    }
}
