using System;
using System.Linq;
using Gtf.Entity;
using Gtf.Implementations;
using Gtf.Interfaces;
using Unity;

namespace Gtf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = new UnityContainer();
                container.RegisterType<IMealFactory, MealFactory>();
                container.RegisterType<IMyContext, MyContext>();

                using (var db = container.Resolve<IMyContext>())
                {

                    var request = MakeRequest();

                    if (Validate(request))
                    {
                        var factory = container.Resolve<IMealFactory>();
                        var periodDescription = request.First().ToLower();
                        var meal = factory.CreateMeal(db, periodDescription);
                        var response = meal.MakeResponse(db, request);
                        Console.Write(response);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    Console.Write(ex.Message);
                else
                    Console.Write("Erro! Tente novamente");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static bool Validate(string[] request)
        {
            foreach (var s in request.Skip(1))
            {
                short outNumber;
                if (!short.TryParse(s, out outNumber))
                    throw new ArgumentException("Pedido inválido");

                if (outNumber < 1 || outNumber > 4)
                    throw new ArgumentException("Pedido inválido");
            }
            return true;
        }

        private static string[] MakeRequest()
        {
            string[] pedidoSplit = { };

            Console.WriteLine("Digite seu pedido: ");

            var pedido = Console.ReadLine();

            if (pedido != null)
                pedidoSplit = pedido.Split(',');
            else
                throw new ArgumentException("Pedido inválido");

            if (pedidoSplit.Length < 4)
                throw new ArgumentException("Pedido inválido");

            return pedidoSplit;
        }
    }
}
