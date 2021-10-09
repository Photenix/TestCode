using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia{
    public class RepositorioPaciente:IRepositorioPaciente{
        private readonly AppContext _appContext;
        //aqui tengo que ver si elimino
        private AppContext appContext;

        public RepositorioPaciente(AppContext appContext)
        {
            this.appContext = appContext;
        }

        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente){
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente){
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id==idPaciente);
            if(pacienteEncontrado==null) return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes(){
            return _appContext.Pacientes;
        }
        Paciente IRepositorioPaciente.GetPaciente(int idPaciente){
            return _appContext.Pacientes.FirstOrDefault(p => p.Id==idPaciente);
        }
        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente){
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id==paciente.Id);
            if(pacienteEncontrado!=null){
                pacienteEncontrado.Nombre =paciente.Nombre;
            }
            _appContext.SaveChanges();
            return pacienteEncontrado;
        }

    }
}