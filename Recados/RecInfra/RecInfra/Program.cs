
using System;
using RecadosInfra;
using RecadosInfra.DAOs;
using System.Collections.Generic;


namespace RecadosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RecadosDAO recadosDAO = new RecadosDAO();

            
            //Recado novoRecado = new Recado
            //{
            //    Id = 1,
            //    Mensagem = "Esta � uma mensagem de teste.",
            //    Remetente = "Jo�o",
            //    Destinatario = "Maria"
            //};
            //recadosDAO.Inserir(novoRecado);
            //Console.WriteLine("Recado inserido com sucesso!");

            
           

            
            //Recado recadoBuscado = recadosDAO.BuscarPorId(1);
            //Console.WriteLine($"Recado buscado: Id={recadoBuscado.Id}, Mensagem={recadoBuscado.Mensagem}, Remetente={recadoBuscado.Remetente}, Destinatario={recadoBuscado.Destinatario}");

            
            List<Recado> todosRecados = recadosDAO.ListarTodos();
            Console.WriteLine("Lista de todos os recados:");
            foreach (var recado in todosRecados)
            {
                Console.WriteLine($"Id={recado.Id}, Mensagem={recado.Mensagem}, Remetente={recado.Remetente}, Destinatario={recado.Destinatario}");
            }

            
        }
    }
}
