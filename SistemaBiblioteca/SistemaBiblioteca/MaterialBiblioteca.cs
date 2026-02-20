using System;

namespace SistemaBiblioteca.Clases
{
    public abstract class MaterialBiblioteca
    {
        private string titulo;
        private string autor;
        private string codigo;
        private bool prestado;

        public MaterialBiblioteca(string titulo, string autor)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.codigo = GenerarCodigo();
            this.prestado = false;
        }

        public string GetTitulo() => titulo;
        public string GetAutor() => autor;
        public string GetCodigo() => codigo;
        public bool IsPrestado() => prestado;

        public void SetPrestado(bool valor)
        {
            prestado = valor;
        }

        private string GenerarCodigo()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] codigoArray = new char[8];

            for (int i = 0; i < 8; i++)
            {
                codigoArray[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(codigoArray);
        }

        public void Prestar()
        {
            if (!prestado)
                prestado = true;
        }

        public void Devolver()
        {
            if (prestado)
                prestado = false;
        }

        public abstract void MostrarInfo();
    }
}