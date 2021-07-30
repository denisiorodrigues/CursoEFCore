using System;
using CursoEFCore.Data;
using CursoEFCore.Model;
using CursoEFCore.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            InserindoDados();
        }

        private static void InserindoDados()
        {
            var produto = new Produto()
            {
                Descricao = "Produto Teste",
                CodigoDeBarras = "234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new ApplicationContext();
            //1-opção
            //db.Produtos.Add(produto);
            //2-opção
            //db.Set<Produto>().Add(produto);
            //3 - opção : Forçando o rastreamento
            db.Entry(produto).State = EntityState.Added;
            //db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registros: {registros}");
        }
    }
}
