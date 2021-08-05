using System;

namespace CursoEFCore.Model
{
    public class Chamado
    {
        public string Codigo { get; set; }

        public string Titulo { get; set; }
        public DateTime Horario { get; set; }
    }
}