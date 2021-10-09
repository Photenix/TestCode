using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

//dotnet ef migrations add Inicial --startup-project
//dotnet ef database update --startup-project
namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddPaciente();
        }
        private static void AddPaciente(){
            var paciente = new Paciente{
                idPaciente = 005,
                Nombre = "Juanito",
                Apellido ="Arandano",
            };
            _repoPaciente.AddPaciente(paciente);
        }
    }
}
