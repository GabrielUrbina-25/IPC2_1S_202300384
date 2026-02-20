using System;

namespace SistemaBiblioteca.Clases
{
    public class LibroDigital : MaterialBiblioteca
    {
        private string tamanoArchivo;
        private int diasMaximo = 3;

        public LibroDigital(string titulo, string autor, string tamanoArchivo)
            : base(titulo, autor)
        {
            this.tamanoArchivo = tamanoArchivo;
        }

        public string GetTamanoArchivo() => tamanoArchivo;

        public override void MostrarInfo()
        {
            string estado = IsPrestado() ? "Prestado" : "Disponible";

            Console.WriteLine(
                $"Libro Digital - Título: {GetTitulo()}, Autor: {GetAutor()}, " +
                $"Tamaño: {tamanoArchivo} MB, Código: {GetCodigo()}, Estado: {estado}");
        }
    }
}