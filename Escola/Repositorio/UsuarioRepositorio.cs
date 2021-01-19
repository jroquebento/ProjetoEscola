using AutoMapper;
using Escola.Data;
using Escola.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        public IEnumerable<Usuario> RetornaTodos() 
        {
            var usuario = db.Usuarios.ToList();
            var listaUsuarios = mapper.Map<IEnumerable<Entidades.Usuario>, IEnumerable<Usuario>>(usuario);
            return listaUsuarios;
        }

        public IEnumerable<Pessoa> RetornaPessoas() 
        {
            var pessoas = db.Pessoas.ToList();
            return mapper.Map<IEnumerable<Entidades.Pessoa>, IEnumerable<Pessoa>>(pessoas);
        }

        public void Create(Usuario usuario) 
        {
            Entidades.Pessoa pessoa = db.Pessoas.Find(usuario.Pessoa.Id);
            var usuarios = mapper.Map<Usuario, Entidades.Usuario>(usuario);

            if (pessoa != null)
            {
                usuarios.Pessoa = pessoa;
            }

            db.Usuarios.Add(usuarios);
            db.SaveChanges();
        }

        public Usuario RetornaPorId(int? id) 
        {
            var usuario = db.Usuarios.Find(id);
            var usuarios = mapper.Map<Entidades.Usuario, Usuario>(usuario);
            return usuarios;
        }

        public void Edit(Usuario usuario) 
        {
            Entidades.Pessoa pessoa = db.Pessoas.Find(usuario.Pessoa.Id);
            var usuarios = mapper.Map<Usuario, Entidades.Usuario>(usuario);
            if (pessoa != null)
            {
                usuarios.Pessoa = pessoa;
            }

            db.Entry(usuarios).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
