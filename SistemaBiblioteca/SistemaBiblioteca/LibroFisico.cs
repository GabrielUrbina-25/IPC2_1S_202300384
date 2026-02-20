using System;

namespace SistemaBiblioteca.Clases
{
    public class LibroFisico : MaterialBiblioteca
    {
        private string numeroEjemplar;
        private int diasMaximo = 7;

        public LibroFisico(string titulo, string autor, string numeroEjemplar)
            : base(titulo, autor)
        {
            this.numeroEjemplar = numeroEjemplar;
        }

        public string GetNumeroEjemplar() => numeroEjemplar;

        public override void MostrarInfo()
        {
            string estado = IsPrestado() ? "Prestado" : "Disponible";

            Console.WriteLine(
                $"Libro Físico - Título: {GetTitulo()}, Autor: {GetAutor()}, " +
                $"Número de Ejemplar: {numeroEjemplar}, Código: {GetCodigo()}, Estado: {estado}");
        }
    }
}