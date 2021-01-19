using AutoMapper;
using Escola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Mappers
{
    public class EscolaProfile : Profile
    {
        public EscolaProfile()
        {
            CreateMap<Entidades.Boletim, Boletim>();
            CreateMap<Boletim, Entidades.Boletim>();
            CreateMap<Entidades.Nota, Nota>();
            CreateMap<Nota, Entidades.Nota>();
            CreateMap<Entidades.Aluno, Aluno>();
            CreateMap<Aluno, Entidades.Aluno>();
            CreateMap<Entidades.Pessoa, Pessoa>();
            CreateMap<Pessoa, Entidades.Pessoa>();
            CreateMap<Entidades.Professor, Professor>();
            CreateMap<Professor, Entidades.Professor>();
            CreateMap<Entidades.Disciplina, Disciplina>();
            CreateMap<Disciplina, Entidades.Disciplina>();
            CreateMap<Entidades.ProfessorDisciplina, ProfessorDisciplina>();
            CreateMap<ProfessorDisciplina, Entidades.ProfessorDisciplina>();
            CreateMap<Entidades.Bimestre, Bimestre>();
            CreateMap<Bimestre, Entidades.Bimestre>();
            CreateMap<Entidades.Usuario, Usuario>();
            CreateMap<Usuario, Entidades.Usuario>();
        } 
    }
}
