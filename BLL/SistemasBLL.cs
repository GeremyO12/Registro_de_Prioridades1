using Microsoft.EntityFrameworkCore;
using Registro_de_Prioridades1.DAL;
using Registro_de_Prioridades1.Models;
using System.Linq.Expressions;

namespace Registro_de_Prioridades1.BLL
{
    public class SistemasBLL
    {
        private readonly RegistroContext _contexto;

        public SistemasBLL(RegistroContext contexto)
        {
            _contexto = contexto;
        }

        //Metodo existe
        public bool Existe(int SistemaId)
        {
            return _contexto.Sistemas.Any(s => s.SistemaId == SistemaId);
        }

        //Metodo insertar
        private bool Insertar(Sistemas Sistema)
        {
            _contexto.Sistemas.Add(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        //Metodo modificar 
        public bool Modificar(Sistemas Sistema)
        {
            _contexto.Update(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        //Metodo gaurdar
        public bool Guardar(Sistemas Sistema)
        {
            //Buscar si el registro existe, si existe lo modifica y si no lo inserta
            if (!Existe(Sistema.SistemaId))
                return Insertar(Sistema);
            else 
                return Modificar(Sistema);
        }

        //Metodo eliminar 
        public bool Eliminar(Sistemas Sistema)
        {
            _contexto.Sistemas.Remove(Sistema);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        //Metodo buscar 
        public Sistemas? Buscar(int SistemaId)
        {
            return _contexto.Sistemas
                .AsNoTracking()
                .FirstOrDefault(s => s.SistemaId == SistemaId);
        }

        //Metodo list
        public List<Sistemas> GetList(Expression<Func<Sistemas, bool>> Criterio)
        {
            return _contexto.Sistemas
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
    }
}
