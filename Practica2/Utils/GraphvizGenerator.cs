using System.Diagnostics;
using System.IO;
using System.Text;
using Practica2.Models;

namespace Practica2.Utils
{
    public class GraphvizGenerator
    {
        public static void Generar(ColaPacientes cola)
        {
            string dot = "digraph G { rankdir=LR; node [shape=box];";

            var lista = cola.ALista();

            for (int i = 0; i < lista.Count; i++)
            {
                dot += $"n{i}[label=\"{lista[i].Nombre}\\n{lista[i].Especialidad}\"];";

                if (i < lista.Count - 1)
                    dot += $"n{i} -> n{i + 1};";
            }

            dot += "}";

            File.WriteAllText("cola.dot", dot);

            Process.Start("cmd", "/c dot -Tpng cola.dot -o cola.png");
        }
    }
}